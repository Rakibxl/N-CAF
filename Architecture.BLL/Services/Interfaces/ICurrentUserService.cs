using System;

namespace Architecture.BLL.Services.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        bool IsAuthenticated { get; }
    }
}
