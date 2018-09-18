using StrukturProjectMVC.Model.Entity;
using StrukturProjectMVC.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrukturProjectMVC.Controller
{
    public interface IMahasiswaController : IBaseController<Mahasiswa>
    {
        Mahasiswa GetByID(string id);
        IList<Mahasiswa> GetByName(string name);
    }

    public class MahasiswaController : IMahasiswaController
    {
        private IMahasiswaRepository _repo;

        public int Delete(Mahasiswa obj)
        {
            throw new NotImplementedException();
        }

        public IList<Mahasiswa> GetAll()
        {
            var listOfMahasiswa = new List<Mahasiswa>();

            using (IDbContext context = new DbContext())
            {
                _repo = new MahasiswaRepository(context);
                listOfMahasiswa = _repo.GetAll().ToList();
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

            using (IDbContext context = new DbContext())
            {
                _repo = new MahasiswaRepository(context);
                listOfMahasiswa = _repo.GetByName(name).ToList();
            }

            return listOfMahasiswa;
        }

        public int Save(Mahasiswa obj)
        {
            var result = 0;

            if (string.IsNullOrEmpty(obj.npm))
            {
                MessageBox.Show("NPM harus diisi !!!");
                return 0;
            }                

            using (IDbContext context = new DbContext())
            {
                _repo = new MahasiswaRepository(context);
                result = _repo.Save(obj);
            }

            return result;
        }

        public int Update(Mahasiswa obj)
        {
            throw new NotImplementedException();
        }
    }
}
