namespace GoogleSearchSeo.Core.Model
{
    public class ServerResponse<T>
    {
        private bool _success = false;

        /// <summary>
        /// Determines if the server response is valid.
        /// </summary>
        public bool Success
        {
            get
            {
                return _success;
            }
            set
            {
                _success = value;
            }
        }

        private T _data;

        /// <summary>
        /// The object that the server response wraps.
        /// </summary>
        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        private Error _error;

        /// <summary>
        /// The error data provided with the server response.
        /// If error is populated, the success flag should be false.
        /// </summary>
        public Error Error
        {
            get
            {
                if (_error == null)
                {
                    _error = new Error();
                }
                return _error;
            }
            set
            {
                _error = value;
            }
        }
    }
}
