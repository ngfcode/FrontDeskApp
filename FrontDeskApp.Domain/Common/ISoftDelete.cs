namespace FrontDeskApp.Domain.Common;

public interface ISoftDelete
{
	byte IsSoftDeleted { get; set; }
}
