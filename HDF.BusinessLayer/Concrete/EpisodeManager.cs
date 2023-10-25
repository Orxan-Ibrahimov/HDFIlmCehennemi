using HDF.BusinessLayer.Abstract;
using HDF.DAL.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.BusinessLayer.Concrete
{
    public class EpisodeManager : IEpisodeService
    {
        private readonly IEpisodeDAL _episodeDAL;

        public EpisodeManager(IEpisodeDAL episodeDAL)
        {
            _episodeDAL = episodeDAL;
        }

        public void Delete(Episode t)
        {
            _episodeDAL.Delete(t);
        }

        public Episode GetById(int id)
        {
           return GetList().First(e=>e.Id == id);
        }

        public List<Episode> GetList()
        {
            return _episodeDAL.GetList().Include(e => e.Season).ThenInclude(s => s.Movie).ToList();
        }

        public void Insert(Episode t)
        {
            _episodeDAL.Insert(t);
        }

        public void Update(Episode t)
        {
            _episodeDAL.Update(t);
        }
    }
}
