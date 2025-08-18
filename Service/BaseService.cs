using Infrastructure.UnityOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaseService
    {
        protected  readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork  unitOfWork ) { 
            _unitOfWork = unitOfWork;
        
        }    
    }
}
