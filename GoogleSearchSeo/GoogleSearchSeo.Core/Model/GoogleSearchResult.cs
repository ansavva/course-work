namespace GoogleSearchSeo.Core.Model
{
    public class GoogleSearchResult
    {
        private int _position = -1;

        /// <summary>
        /// The position of the search result in the list of search results returned.
        /// </summary>
        public int Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        private string _headingText;

        /// <summary>
        /// The heading for the retrieved search result.
        /// </summary>
        public string HeadingText
        {
            get
            {
                if (_headingText == null)
                {
                    _headingText = string.Empty;
                }
                return _headingText;
            }
            set
            {
                _headingText = value;
            }
        }

        private string _description;

        /// <summary>
        /// The description for the retrieved search result.
        /// </summary>
        public string Description
        {
            get
            {
                if (_description == null)
                {
                    _description = string.Empty;
                }
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        private string _resultUrl;

        /// <summary>
        /// The url for the retrieved search result.
        /// </summary>
        public string ResultUrl
        {
            get
            {
                if (_resultUrl == null)
                {
                    _resultUrl = string.Empty;
                }
                return _resultUrl;
            }
            set
            {
                _resultUrl = value;
            }
        }

        private bool _isMatch = false;

        public bool IsMatch
        {
            get
            {
                return _isMatch;
            }
            set
            {
                _isMatch = value;
            }
        }
    }
}
