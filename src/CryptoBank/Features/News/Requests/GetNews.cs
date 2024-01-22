using CryptoBank.Database;
using CryptoBank.Features.News.Models;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CryptoBank.Features.News.Requests;

public static class GetNews
{
    [HttpGet("/news")]
    [AllowAnonymous]
    public class Endpoint : Endpoint<Request, NewsModel[]>
    {
        private readonly IMediator _mediator;

        public Endpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<NewsModel[]> ExecuteAsync(Request request, CancellationToken cancellationToken) =>
            await _mediator.Send(request, cancellationToken);
    }

    public record Request() : IRequest<NewsModel[]>;

    public class RequestHandler : IRequestHandler<Request, NewsModel[]>
    {
        private readonly CryptoBankDbContext _dbContext;

        public RequestHandler(CryptoBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NewsModel[]> Handle(Request request, CancellationToken cancellationToken) =>
            await _dbContext.News.Select(z => new NewsModel
            {
                Id = z.Id,
                Title = z.Title,
                Date = z.Date,
                Author = z.Author,
                Content = z.Content

            }).
            ToArrayAsync(cancellationToken);
    }
}
