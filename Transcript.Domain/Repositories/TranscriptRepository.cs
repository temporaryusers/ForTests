using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcript.Domain.Context;
using Transcript.Domain.Interfaces;

namespace Transcript.Domain.Repositories
{
    public class TranscriptRepository : ITranscriptRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Transcript.Domain.Entities.Transcript> Transcripts
        {
            get
            {
                return context.Transcripts;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Create(Entities.Transcript transcript)
        {
            context.Transcripts.Add(transcript);

            Save();
        }

        public void Edit(Entities.Transcript transcript)
        {
            context.Entry(transcript).State = EntityState.Modified;

            Save();
        }

        public void Delete(int id)
        {
            Entities.Transcript transcript = context.Transcripts.Find(id);

            context.Transcripts.Remove(transcript);

            Save();
        }
    }
}
