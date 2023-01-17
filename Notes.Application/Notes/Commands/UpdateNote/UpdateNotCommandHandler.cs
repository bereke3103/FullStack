﻿
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNotCommandHandler
        : IRequestHandler<UpdateNoteCommand>
    {

        private readonly INotesDbContext _dbContext;

        public UpdateNotCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;


            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}