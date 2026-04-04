namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet]
	public async Task<IActionResult> GetTodos(CancellationToken cancellationToken)
	{
		var result = await _mediator
			.Send(new GetTodosQuery(), cancellationToken);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("id/{id:guid}")]
	public async Task<IActionResult> GetTodoById([FromRoute] Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator
			.Send(new GetTodoByIdQuery(id), cancellationToken);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost()]
	public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator
			.Send(new CreateTodoCommand(request.Title), cancellationToken);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, [FromBody] UpdateTodoRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator
			.Send(new UpdateTodoCommand(id, request.Title, request.IsCompleted), cancellationToken);

		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteTodo([FromRoute] Guid id, CancellationToken cancellationToken)
	{
		var result = await _mediator
			.Send(new DeleteTodoCommand(id), cancellationToken);

		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
}