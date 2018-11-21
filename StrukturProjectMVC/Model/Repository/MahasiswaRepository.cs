using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

using StrukturProjectMVC.Model.Entity;
using StrukturProjectMVC.Model.Context;

namespace StrukturProjectMVC.Model.Repository
{
    public interface IMahasiswaRepository : IBaseRepository<Mahasiswa>
    {
        Mahasiswa GetByID(string id);
        IList<Mahasiswa> GetByName(string name);
    }

    public class MahasiswaRepository : IMahasiswaRepository
    {
        private IDbContext _context;

        public MahasiswaRepository(IDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method untuk merubah row menjadi object
        /// </summary>
        /// <param name="dtr"></param>
        /// <returns></returns>
        private Mahasiswa RowMapper(OleDbDataReader dtr)
        {
            var mhs = new Mahasiswa();

            mhs.npm = dtr["npm"] == DBNull.Value ? string.Empty : dtr["npm"].ToString();
            mhs.nama = dtr["nama"] == DBNull.Value ? string.Empty : dtr["nama"].ToString();
            mhs.alamat = dtr["alamat"] == DBNull.Value ? string.Empty : dtr["alamat"].ToString();

            return mhs;
        }

        public int Delete(Mahasiswa obj)
        {
            throw new NotImplementedException();
        }

        public IList<Mahasiswa> GetAll()
        {
            var listOfMahasiswa = new List<Mahasiswa>();

            var sql = @"select * from mahasiswa order by nama";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                using (var dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        listOfMahasiswa.Add(RowMapper(dtr));
                    }
                }
            }

            return listOfMahasiswa;
        }

        public Mahasiswa GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Mahasiswa> GetByName(string name)
        {
            var listOfMahasiswa = new List<Mahasiswa>();

            var sql = @"select * from mahasiswa 
                        where nama like @name
                        order by nama";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                cmd.Parameters.AddWithValue("@name", "%" + name + "%");

                using (var dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        listOfMahasiswa.Add(RowMapper(dtr));
                    }
                }
            }

            return listOfMahasiswa;
        }

        public int Save(Mahasiswa obj)
        {
            var result = 0;

            var sql = @"insert into mahasiswa (npm, nama, alamat)
                        values (@npm, @nama, @alamat)";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                cmd.Parameters.AddWithValue("@npm", obj.npm);
                cmd.Parameters.AddWithValue("@nama", obj.nama);
                cmd.Parameters.AddWithValue("@alamat", obj.alamat);

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Update(Mahasiswa obj)
        {
            throw new NotImplementedException();
        }
    }
}
