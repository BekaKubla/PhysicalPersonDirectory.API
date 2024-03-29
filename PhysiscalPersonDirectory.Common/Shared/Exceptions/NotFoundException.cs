﻿using PhysiscalPersonDirectory.Common.Shared.Resource;

namespace PhysiscalPersonDirectory.Common.Shared.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string name, string property, object key)
           : base(string.Format(ErrorMessages.NotFoundException, name, property, key))
        {
        }
    }
}
