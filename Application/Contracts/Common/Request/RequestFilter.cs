namespace Application.Contracts.Common.Request;

public class RequestFilter 
{
	public int PageNumber { get; init; } = 1;
	public int PageSize { get; init; } = 10;
}