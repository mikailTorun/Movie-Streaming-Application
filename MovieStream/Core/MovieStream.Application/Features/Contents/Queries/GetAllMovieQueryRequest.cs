using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetAllMovieQueryRequest : IRequest<GetAllMovieQueryResponse>
    {
        public Guid UserId { get; set; }
    }
}
