using System;

namespace Menou.Services.Core.Model
{
    public class MenuItem
    {
        private int _id = -1;
        private string _title;
        private string _description;
        private DateTime _createdDate = DateTime.Now;
        private DateTime _modifiedDate = DateTime.Now;

        public int Id { get => _id; set => _id = value; }
        public string Title {
            get
            {
                if (_title == null)
                {
                    _title = string.Empty;
                }
                return _title;
            }
            set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime ModifiedDate { get => _modifiedDate; set => _modifiedDate = value; }
    }
}
