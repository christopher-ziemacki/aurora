using System;

namespace Aurora.Integration.Contracts
{
    public interface INurturePlanCreated
    {
        Guid OrganizationId { get; set; }
        Guid NurturePlanId { get; set; }
    }
}