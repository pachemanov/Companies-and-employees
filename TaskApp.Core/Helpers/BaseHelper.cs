using System;
using System.Collections.Generic;
using System.Text;
using TaskApp.DAL.UnitOfWork.Contracts;

namespace TaskApp.Core.Helpers
{
    public abstract class BaseHelper
    {
        protected IUnitOfWork db;

        public BaseHelper(IUnitOfWork db)
        {
            this.db = db;
        }
    }
}
