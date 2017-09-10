using System;
using System.Collections.Generic;

namespace Ecommerce.Core.Model
{
    public class Restaurant
    {
        private int _id;
        private string _name;
        private DateTime _createdDate = DateTime.Now;
        private DateTime _modifiedDate = DateTime.Now;
        private List<MenuItem> _menuItems;

        public int Id { get => _id; set => _id = value; }
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set => _name = value;
        }

        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime ModifiedDate { get => _modifiedDate; set => _modifiedDate = value; }
        public List<MenuItem> MenuItems
        {
            get
            {
                if (_menuItems == null)
                {
                    _menuItems = new List<MenuItem>();
                }
                return _menuItems;
            }
            set => _menuItems = value;
        }
    }
}
