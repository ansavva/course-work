
export class GoogleSearchResult {
    Position: KnockoutObservable<number> = ko.observable(0);
    HeadingText: KnockoutObservable<string> = ko.observable("");
    Description: KnockoutObservable<string> = ko.observable("");
    ResultUrl: KnockoutObservable<string> = ko.observable("");
    IsMatch: KnockoutObservable<boolean> = ko.observable(false);
}

export class ServerResponse<T> {
    Success: boolean = false;
    Data: T;
    Error: Error;
}

export class Error {
    Message: string = "";
    StackTrace: string = "";
    CustomMessage: string = ""
    Source: string = "";
}