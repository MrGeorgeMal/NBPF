using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.Blueprint
{
    public class BPLine : BPObject
    {
        #region Private Member
        private float x1 = 0.0f;
        private float y1 = 0.0f;
        private float x2 = 100.0f;
        private float y2 = 100.0f;
        #endregion



        #region Public Member
        #endregion



        #region Constructor
        public BPLine() : base() { }
        #endregion



        #region Protected Member
        protected override void SetupObject()
        {
            
        }
        #endregion
    }
}
