using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmds.Data;

namespace Tmds.Components
{

    public class Tracks
        : IEnumerable<Track>, ICollection<Track>, IList<Track>
    {

        private List<Track> _list;

        public Tracks()
        {
            _list = new List<Track>();
        }


        public Track this[int index]
        {
            get
            {
                return _list[index];
            }

            set
            {
                _list[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Track item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(Track item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(Track[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Track> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(Track item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, Track item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(Track item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void LoadByTerritory(int territoryId) 
        {
            var db = new TmdsStaticDataContext();

            var qry = from t in db.tblCompTracks
                      where t.TerritoryAssignment == territoryId
                      select t;

            foreach (tblCompTrack ti in qry)
            {

                Track t = new Track(ti);
                _list.Add(t);
            }

        }

        public void Load<T>(params int[] trackIds) 
        {
            var db = new TmdsStaticDataContext();

            var qry = from t in db.tblCompTracks
                      where trackIds.Contains(t.UID)
                      select t;

            foreach (tblCompTrack ti in qry)
            {
                Track t = new Track(ti);
                _list.Add(t);
            }

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeRush", "Can combine initialization with declaration")]
        public void Load<T>(int subdivisionId, float mp1, float mp2) where T : Track
        {

            float mpLow = Math.Min(mp1, mp2);
            float mpHigh = Math.Max(mp1, mp2);


            var db = new TmdsStaticDataContext();

            List<tblCompTrack> lst = new List<tblCompTrack>();

            IQueryable<tblCompTrack> qry;

            // Check for tracks that ascend left to right.
            qry = from t in db.tblCompTracks
                      where t.LeftLimitMPRange <= t.RightLimitMPRange
                            &&  mpLow >= t.LeftLimitMPRange 
                            &&  mpHigh <= t.RightLimitMPRange
                            &&  t.Subdivision == subdivisionId
                      select t;
            lst.AddRange(qry);

            // Check for tracks that descend left to right
            qry = from t in db.tblCompTracks
                  where t.LeftLimitMPRange > t.RightLimitMPRange
                        && mpLow >= t.RightLimitMPRange
                        && mpHigh <= t.LeftLimitMPRange
                        && t.Subdivision == subdivisionId
                  select t;
            lst.AddRange(qry);

            var dlist = lst.Distinct();
                  

            foreach (tblCompTrack ti in dlist)
            {
                Track t = new Track(ti);
                _list.Add(t);
            }
        }

    }
}
