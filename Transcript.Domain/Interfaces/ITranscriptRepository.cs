using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcript.Domain.Interfaces
{
    public interface ITranscriptRepository
    {
        IEnumerable<Transcript.Domain.Entities.Transcript> Transcripts { get; }

        void Save();

        void Create(Transcript.Domain.Entities.Transcript transcript);

        void Edit(Transcript.Domain.Entities.Transcript transcript);

        void Delete(int id);
    }
}
