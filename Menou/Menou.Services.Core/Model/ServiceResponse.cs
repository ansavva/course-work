namespace Menou.Services.Core.Model
{
    public class ServiceResponse<T>
    {
        private bool _success;
        private T _data;
        private MenouError _error;

        public bool Success { get => _success; set => _success = value; }
        public T Data { get => _data; set => _data = value; }
        private MenouError Error
        {
            get
            {
                if (_error == null)
                {
                    _error = new MenouError();
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
