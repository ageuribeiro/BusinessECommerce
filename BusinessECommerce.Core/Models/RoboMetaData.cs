using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessECommerce.Core.Models
{
    public class RoboMetaData
    {
        public int Id { get; set; }
        public string? CodClass { get; set; }    
        public bool Ativo { get; set; } 
    }

    public class RoboRepository
    {
        private string _connString = "";
        public RoboMetaData? ObterConfiguracaoRobo(int IdRobo)
        {
            using (var db = new SqlConnection(_connString))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, CodClass, Ativo FROM RoboMetaData WHERE Id = @IdRobo";
                    var param = cmd.CreateParameter();
                    param.ParameterName = "@IdRobo";
                    param.Value = IdRobo;
                    cmd.Parameters.Add(param);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RoboMetaData
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CodClass = reader.IsDBNull(reader.GetOrdinal("CodClass")) ? null : reader.GetString(reader.GetOrdinal("CodClass")),
                                Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"))
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
