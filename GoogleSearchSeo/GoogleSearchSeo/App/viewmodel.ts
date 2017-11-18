import * as Model from './model';

export class IndexViewModel {
    GoogleSearchResults: KnockoutObservableArray<Model.GoogleSearchResult> = ko.observableArray<Model.GoogleSearchResult>([]);
    MatchingGoogleSearchResults: KnockoutObservableArray <Model.GoogleSearchResult> = ko.observableArray<Model.GoogleSearchResult>([]);

    SearchTerm: KnockoutObservable<string> = ko.observable(null).extend({ required: true });

    SearchCount: KnockoutObservable<number> = ko.observable(100).extend(
        {
            required: true,
            mustMatch: ['^\\d+$', 'numeric'],
            lessThanOrEqualTo: 100,
            greaterThan: 0
        });

    MatchUrl: KnockoutObservable<string> = ko.observable(null).extend({ required: true });

    Errors: KnockoutValidationErrors = ko.validation.group(this);

    ErrorMessage: KnockoutObservable<string> = ko.observable(null);

    GetGoogleSearchResults(): void {
        if (this.Errors().length > 0) {
            this.Errors.showAllMessages();
        }
        else {
            this.GoogleSearchResults([]); // Clear the Google Search Results list
            this.MatchingGoogleSearchResults([]); // Clear the Matching Google Search Results list
            this.ErrorMessage(null); // Clear the error message

            $.ajax({
                url: '/Home/SearchResults',
                type: 'GET',
                dataType: 'json',
                data: {
                    "searchTerm": this.SearchTerm(), "searchCount": this.SearchCount(), "matchUrl": this.MatchUrl()
                },
                success: (result: Model.ServerResponse<Array<any>>): void => {
                    if (result.Success && result.Data && result.Data.length > 0) {
                        for (let searchResult of result.Data) {
                            if (searchResult) {
                                searchResult = ko.mapping.fromJS<Model.GoogleSearchResult>(searchResult);
                                if (searchResult.IsMatch()) {
                                    this.MatchingGoogleSearchResults.push(searchResult);
                                }
                                this.GoogleSearchResults.push(searchResult);
                            }
                        }

                        if (this.MatchingGoogleSearchResults().length == 0)
                        {
                            this.ErrorMessage("No matching results found in the top " + this.SearchCount() + " search results. Please try again.");
                        }
                    }
                    else {
                        this.ErrorMessage("No results found. Please try again.");
                    }
                },
                error: (data): void => {
                    this.ErrorMessage("No results found. Please try again.");
                }
            });
        }
    }

    InvalidateInput(data, event): void {
        $(event).attr('class', 'error');
    }
}

$(document).ready(function () {
    // Configure knockout validation
    ko.validation.init({
        registerExtenders: true,
        messagesOnModified: true,
        insertMessages: false,
        parseInputAttributes: true,
        messageTemplate: null
    }, true);


    // Setup custom rule for regular expression validation in knockout
    ko.validation.rules['mustMatch'] = {
        validator: function (val, params) {
            var reg = new RegExp(params[0]);
            return reg.test(val);
        },
        message: 'This field must be {1}.'
    };

    // Setup custom rule for regular expression validation in knockout
    ko.validation.rules['lessThanOrEqualTo'] = {
        validator: function (val, param) {
            return val <= param;
        },
        message: 'This field must be less than or equal to {0}.'
    };

    ko.validation.rules['greaterThan'] = {
        validator: function (val, param) {
            return val > param;
        },
        message: 'This field must be greater than {0}.'
    }

    // Register all csutomer validation scripts
    ko.validation.registerExtenders();

    // Bootstrap knockout
    ko.applyBindings(new IndexViewModel());
});