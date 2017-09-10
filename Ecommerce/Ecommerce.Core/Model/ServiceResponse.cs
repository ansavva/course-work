namespace Ecommerce.Core.Model
{
    public class ServiceResponse<T>
    {
        private bool _success = false;
        private T _data;
        private EcommerceError _error;

        public bool Success { get => _success; set => _success = value; }
        public T Data { get => _data; set => _data = value; }
        private EcommerceError Error
        {
            get
            {
                if (_error == null)
                {
                    _error = new EcommerceError();
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
