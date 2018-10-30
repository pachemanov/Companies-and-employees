using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskApp.Core.Managers
{
    public abstract class BaseManager
    {
        protected IMapper mapper;

        public BaseManager(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
