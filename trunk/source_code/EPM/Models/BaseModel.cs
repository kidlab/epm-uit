using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Common;

namespace EPM.Models
{
    /// <summary>
    /// Base Model class.
    /// @author: ManVHT
    /// @date: 2010-01-06
    /// </summary>
    public class BaseModel
    {
        #region VARIABLES

        protected EpmDataContext _db;  
        protected bool _autoSubmitChanges;
        protected bool _isDataContextShared;

        /// <summary>
        /// Gets or sets the value determining that the model will automatically submit all changes to DB or not. The default value is False.
        /// </summary>
        public bool AutoSubmitChanges
        {
            get
            {
                return _autoSubmitChanges;
            }
            set
            {
                _autoSubmitChanges = value;
            }
        }

        /// <summary>
        /// Gets the value indicating that EpmDataContext is shared across model classes or not.
        /// </summary>
        public bool IsDataContextShared
        {
            get { return _isDataContextShared; }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Creates a new instance of BaseModel with a new EpmDataContext.
        /// </summary>
        public BaseModel()
        {
            _refreshDataContext();
            _autoSubmitChanges = false;
            _isDataContextShared = false;
        }

        /// <summary>
        /// Creates a new instance of BaseModel with a EpmDataContext shared across model classes.
        /// </summary>
        /// <param name="sharedDataContext">The shared EpmDataContext.</param>
        public BaseModel(EpmDataContext sharedDataContext)
        {
            _db = sharedDataContext;
            _autoSubmitChanges = false;
            _isDataContextShared = true;
        }

        #endregion

        #region UTILITIY METHODS
        
        /// <summary>
        /// Submit all changes and refresh DataContext 
        /// if the value _autoSubmitChanges is True.
        /// </summary>
        protected virtual void _save()
        {
            try
            {
                if (_autoSubmitChanges)
                    this.Save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BaseModel), exc);
                throw new DbAccessException(exc);
            }
        }

        protected void _refreshDataContext()
        {
            // Should not re-create data context in shared mode,
            // because of conflicting data.
            if(!_isDataContextShared)
                _db = new EpmDataContext();
        }

        /// <summary>
        /// Submit all changes to DB and refresh the data context.
        /// </summary>
        public virtual void Save()
        {
            try
            {
                _db.SubmitChanges();
                _refreshDataContext();                
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BaseModel), exc);
                throw new DbAccessException(exc);
            }
        }

        /// <summary>
        /// Use this method to share one DataContext across model classes 
        /// to avoid conflict when submiting data to DB.
        /// </summary>
        /// <param name="dataContext">An instance of EpmDataContext.</param>
        public virtual void ShareDataContext(EpmDataContext dataContext)
        {
            _db = dataContext;
        }

        #endregion
    }
}
