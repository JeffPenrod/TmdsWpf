using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tmds.Data;

namespace Tmds.Components
{
    public class Tags
        : IEnumerable<Tag>, ICollection<Tag>, IList<Tag>
    {

        private List<Tag> _list = new List<Tag>();

        public Tag this[int index]
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

        public void Add(Tag item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(Tag item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(Tag[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Tag> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(Tag item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, Tag item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(Tag item)
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

        public void Load(int territoryId)
        {

            var db = new TmdsDynamicDataContext();

            var qry = from t in db.tblTrackTagsActives
                      where t.TerritoryID == territoryId
                      select t;

            foreach (tblTrackTagsActive ta in qry)
            {
                Tag t = null;

                switch (ta.TagType)
                {
                    case "SPEED":
                        t = new SpeedTag(ta);
                        break;
                    case "XING":
                        t = new CrossingTag(ta);
                        break;
                    case "INFO":
                        t = new InfoTag(ta);
                        break;
                    case "WEATHER":
                        t = new WeatherTag(ta);
                        break;
                }

                if (t == null) continue;

                _list.Add(t);

            }

        }

        public int AttachToTracks(Tracks tracks)
        {
            int attachCount = 0;

            foreach (Tag t in this)
            {
                var qry = from track in tracks
                          where track.Guid == t.TrackGuid
                          select track;

                Track trk = qry.FirstOrDefault();

                if (trk == null) continue;

                trk.Tags.Add(t);
                t.AffectedTracks.Add(trk);

                attachCount++;

            }

            return attachCount;
        }
    }
}
