//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

[DataContract(IsReference = true)]
[KnownType(typeof(StockSymbol))]
[KnownType(typeof(StockFile))]
public partial class StockSymbol: IObjectWithChangeTracker, INotifyPropertyChanged
{
    #region Primitive Properties

    [DataMember]
    public int ID
    {
        get { return _iD; }
        set
        {
            if (_iD != value)
            {
                if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                {
                    throw new InvalidOperationException("The property 'ID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                }
                if (!IsDeserializing)
                {
                    if (StockSymbol2 != null && StockSymbol2.ID != value)
                    {
                        StockSymbol2 = null;
                    }
                }
                _iD = value;
                OnPropertyChanged("ID");
            }
        }
    }
    private int _iD;

    [DataMember]
    public string Symbol
    {
        get { return _symbol; }
        set
        {
            if (_symbol != value)
            {
                _symbol = value;
                OnPropertyChanged("Symbol");
            }
        }
    }
    private string _symbol;

    #endregion

    #region Navigation Properties

    [DataMember]
    public StockSymbol StockSymbol1
    {
        get { return _stockSymbol1; }
        set
        {
            if (!ReferenceEquals(_stockSymbol1, value))
            {
                var previousValue = _stockSymbol1;
                _stockSymbol1 = value;
                FixupStockSymbol1(previousValue);
                OnNavigationPropertyChanged("StockSymbol1");
            }
        }
    }
    private StockSymbol _stockSymbol1;

    [DataMember]
    public StockSymbol StockSymbol2
    {
        get { return _stockSymbol2; }
        set
        {
            if (!ReferenceEquals(_stockSymbol2, value))
            {
                if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && value != null)
                {
                    // This the dependent end of an identifying relationship, so the principal end cannot be changed if it is already set,
                    // otherwise it can only be set to an entity with a primary key that is the same value as the dependent's foreign key.
                    if (ID != value.ID)
                    {
                        throw new InvalidOperationException("The principal end of an identifying relationship can only be changed when the dependent end is in the Added state.");
                    }
                }
                var previousValue = _stockSymbol2;
                _stockSymbol2 = value;
                FixupStockSymbol2(previousValue);
                OnNavigationPropertyChanged("StockSymbol2");
            }
        }
    }
    private StockSymbol _stockSymbol2;

    [DataMember]
    public TrackableCollection<StockFile> StockFiles
    {
        get
        {
            if (_stockFiles == null)
            {
                _stockFiles = new TrackableCollection<StockFile>();
                _stockFiles.CollectionChanged += FixupStockFiles;
            }
            return _stockFiles;
        }
        set
        {
            if (!ReferenceEquals(_stockFiles, value))
            {
                if (ChangeTracker.ChangeTrackingEnabled)
                {
                    throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                }
                if (_stockFiles != null)
                {
                    _stockFiles.CollectionChanged -= FixupStockFiles;
                }
                _stockFiles = value;
                if (_stockFiles != null)
                {
                    _stockFiles.CollectionChanged += FixupStockFiles;
                }
                OnNavigationPropertyChanged("StockFiles");
            }
        }
    }
    private TrackableCollection<StockFile> _stockFiles;

    #endregion

    #region ChangeTracking

    protected virtual void OnPropertyChanged(String propertyName)
    {
        if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
        {
            ChangeTracker.State = ObjectState.Modified;
        }
        if (_propertyChanged != null)
        {
            _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    protected virtual void OnNavigationPropertyChanged(String propertyName)
    {
        if (_propertyChanged != null)
        {
            _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
    private event PropertyChangedEventHandler _propertyChanged;
    private ObjectChangeTracker _changeTracker;

    [DataMember]
    public ObjectChangeTracker ChangeTracker
    {
        get
        {
            if (_changeTracker == null)
            {
                _changeTracker = new ObjectChangeTracker();
                _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
            }
            return _changeTracker;
        }
        set
        {
            if(_changeTracker != null)
            {
                _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
            }
            _changeTracker = value;
            if(_changeTracker != null)
            {
                _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
            }
        }
    }

    private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
    {
        if (e.NewState == ObjectState.Deleted)
        {
            ClearNavigationProperties();
        }
    }

    protected bool IsDeserializing { get; private set; }

    [OnDeserializing]
    public void OnDeserializingMethod(StreamingContext context)
    {
        IsDeserializing = true;
    }

    [OnDeserialized]
    public void OnDeserializedMethod(StreamingContext context)
    {
        IsDeserializing = false;
        ChangeTracker.ChangeTrackingEnabled = true;
    }

    // This entity type is the dependent end in at least one association that performs cascade deletes.
    // This event handler will process notifications that occur when the principal end is deleted.
    internal void HandleCascadeDelete(object sender, ObjectStateChangingEventArgs e)
    {
        if (e.NewState == ObjectState.Deleted)
        {
            this.MarkAsDeleted();
        }
    }

    protected virtual void ClearNavigationProperties()
    {
        StockSymbol1 = null;
        StockSymbol2 = null;
        StockFiles.Clear();
    }

    #endregion

    #region Association Fixup

    private void FixupStockSymbol1(StockSymbol previousValue)
    {
        // This is the principal end in an association that performs cascade deletes.
        // Update the event listener to refer to the new dependent.
        if (previousValue != null)
        {
            ChangeTracker.ObjectStateChanging -= previousValue.HandleCascadeDelete;
        }

        if (StockSymbol1 != null)
        {
            ChangeTracker.ObjectStateChanging += StockSymbol1.HandleCascadeDelete;
        }

        if (IsDeserializing)
        {
            return;
        }

        if (previousValue != null && ReferenceEquals(previousValue.StockSymbol2, this))
        {
            previousValue.StockSymbol2 = null;
        }

        if (StockSymbol1 != null)
        {
            StockSymbol1.StockSymbol2 = this;
        }

        if (ChangeTracker.ChangeTrackingEnabled)
        {
            if (ChangeTracker.OriginalValues.ContainsKey("StockSymbol1")
                && (ChangeTracker.OriginalValues["StockSymbol1"] == StockSymbol1))
            {
                ChangeTracker.OriginalValues.Remove("StockSymbol1");
            }
            else
            {
                ChangeTracker.RecordOriginalValue("StockSymbol1", previousValue);
                // This is the principal end of an identifying association, so the dependent must be deleted when the relationship is removed.
                // If the current state of the dependent is Added, the relationship can be changed without causing the dependent to be deleted.
                if (previousValue != null && previousValue.ChangeTracker.State != ObjectState.Added)
                {
                    previousValue.MarkAsDeleted();
                }
            }
            if (StockSymbol1 != null && !StockSymbol1.ChangeTracker.ChangeTrackingEnabled)
            {
                StockSymbol1.StartTracking();
            }
        }
    }

    private void FixupStockSymbol2(StockSymbol previousValue)
    {
        if (IsDeserializing)
        {
            return;
        }

        if (previousValue != null && ReferenceEquals(previousValue.StockSymbol1, this))
        {
            previousValue.StockSymbol1 = null;
        }

        if (StockSymbol2 != null)
        {
            StockSymbol2.StockSymbol1 = this;
            ID = StockSymbol2.ID;
        }

        if (ChangeTracker.ChangeTrackingEnabled)
        {
            if (ChangeTracker.OriginalValues.ContainsKey("StockSymbol2")
                && (ChangeTracker.OriginalValues["StockSymbol2"] == StockSymbol2))
            {
                ChangeTracker.OriginalValues.Remove("StockSymbol2");
            }
            else
            {
                ChangeTracker.RecordOriginalValue("StockSymbol2", previousValue);
            }
            if (StockSymbol2 != null && !StockSymbol2.ChangeTracker.ChangeTrackingEnabled)
            {
                StockSymbol2.StartTracking();
            }
        }
    }

    private void FixupStockFiles(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (IsDeserializing)
        {
            return;
        }

        if (e.NewItems != null)
        {
            foreach (StockFile item in e.NewItems)
            {
                item.StockSymbol = this;
                if (ChangeTracker.ChangeTrackingEnabled)
                {
                    if (!item.ChangeTracker.ChangeTrackingEnabled)
                    {
                        item.StartTracking();
                    }
                    ChangeTracker.RecordAdditionToCollectionProperties("StockFiles", item);
                }
            }
        }

        if (e.OldItems != null)
        {
            foreach (StockFile item in e.OldItems)
            {
                if (ReferenceEquals(item.StockSymbol, this))
                {
                    item.StockSymbol = null;
                }
                if (ChangeTracker.ChangeTrackingEnabled)
                {
                    ChangeTracker.RecordRemovalFromCollectionProperties("StockFiles", item);
                }
            }
        }
    }

    #endregion

}