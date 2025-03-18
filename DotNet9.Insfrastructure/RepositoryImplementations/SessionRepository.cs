using DotNet9.Domain.DatabaseEntities;
using DotNet9.Domain.RepositoryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DotNet9.Insfrastructure.RepositoryImplementations
{
    public class SessionRepository : ISessionRepository
    {   private readonly DotNet9DbContext _dbContext;
        public SessionRepository(DotNet9DbContext dbContext) {
        _dbContext = dbContext;
        }
        public async Task<List<Session>> SessionsWithSongNotesOld()
        {
            using (var sqlConnection1 = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=DotNet9.Db;Trusted_Connection=true;TrustServerCertificate=True;Integrated Security=true;"))
            {
                using (var cmd = new SqlCommand()
                {
                    CommandText = "select ses.Name , count(*) from Sessions ses inner join Songs so on so.SessionId = ses.Id group by ses.Name",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                })
                {



                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {


                            var id = reader[0];
                            var name = reader[1];
                            // get the rest of the columns you need the same way
                        }
                    }
                }
                }
                return new List<Session>();
        }


        public async Task<List<Session>> SessionsWithSongNotes()
        {
           return await  _dbContext.Sessions.Include(item => item.Songs).ToListAsync();
        }
    }
}
