using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Responses
{
    public class ApiEntityResponse<T>
    {
        private readonly T? _entity;

        public ApiEntityResponse(T entity)
        {
            _entity = entity;
        }

        public ApiEntityResponse(Exception ex)
        {
            Error = ex;
        }

        public T Content
        {
            get
            {
                if (_entity == null)
                {
                    throw Error!;
                }
                else
                {
                    return _entity;
                }
            }
        }

        public Exception? Error { get; }

        public bool HasError => Error != null;
    }
}
