using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Excelsior.Core.Models.Document
{

    public abstract class DetailsBase : Collection<DetailBase>, IBindingList, IList, ICollection, IEnumerable, INotifyPropertyChanged
    {
        private DocumentBase _parent;
        public DocumentBase Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        public bool AllowEdit
        {
            get { return true; }
        }

        public bool AllowNew
        {
            get { return true; }
        }

        public bool AllowRemove
        {
            get { return true; }
        }

        public bool IsSorted
        {
            get { return true; }
        }

        public ListSortDirection SortDirection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PropertyDescriptor SortProperty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        public bool SupportsSearching
        {
            get { return true; }
        }

        public bool SupportsSorting
        {
            get { return true; }
        }

        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        new public void Add(DetailBase dtl)
        {
            dtl.Parent = this;
            dtl.PropertyChanged += delegate (object s, PropertyChangedEventArgs e)
            {
                this.ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemChanged, dtl.Parent.Count == 0 ? 0 : dtl.Parent.Count - 1));
            };
            base.Add(dtl);
            this.ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemAdded, dtl.Parent.Count == 0 ? 0 : dtl.Parent.Count - 1));
        }

        public abstract object AddNew();

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }
        public new void Remove(DetailBase dtl)
        {
            base.Remove(dtl);

            dtl.Delete();
            this.ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, 0));
        }

        public new void Clear()
        {
            // base.Clear();
            base.ClearItems();
            this.ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, 0));
        }

        public void RemoveSort()
        {
            throw new NotImplementedException();
        }

        public new int IndexOf(DetailBase dtl)
        {
            return base.IndexOf(dtl);
        }

        public DetailsBase(DocumentBase parent)
        {
            _parent = parent;
        }

        #region EVENTS
        public event PropertyChangedEventHandler PropertyChanged;
        public event ListChangedEventHandler ListChanged;
        protected virtual void OnListChangedEvent(object sender, ListChangedEventArgs args)
        {
            ListChangedEventHandler handler = sender as ListChangedEventHandler;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion EVENTS
        #region MY METHODS

        #endregion

    }
}
