using CitizenFX.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace xCoreClient.Main.Player.Markers
{
    public class MarkClass : BaseScript
    {
        private Vector3 pos = Vector3.Zero, rot = Vector3.Zero, scale = Vector3.Zero, dir = Vector3.Zero;
        private Delegate onEnter_, onExit_, onkey_;
        private int distance = 30, id;
        private Dictionary<string, List<string>> allowed = new Dictionary<string, List<string>>();
        private MarkerType type;
        private Color color;

        public void onEnter(Delegate del) => onEnter_ = del;
        public void onExit(Delegate del)  => onExit_  = del;
        public void onKey(Delegate del)   => onkey_   = del;

        public Delegate onEnterDelegate() => onEnter_;
        public Delegate onExitDelegate() => onExit_;
        public Delegate onKeyDelegate() => onkey_;

        public void    setPosition(Vector3 result) => this.pos = result;
        public Vector3 getPosition() => this.pos;

        public void    setDirectory(Vector3 result) => this.dir = result;
        public Vector3 getDirectory() => this.dir;

        public void    setRotation(Vector3 result) => this.rot = result;
        public Vector3 getRotation() => this.rot;

        public void    setScale(Vector3 result) => this.scale = result;
        public Vector3 getScale() => this.scale;

        public void  setColor(Color result) => this.color = result;
        public Color getColor() => this.color;

        public void visibleToJob(string jobName, List<string> grades) => this.allowed.Add(jobName, grades);

        public Dictionary<string, List<string>> getJobList() => allowed;

        public bool getJobs(string job,string grade)
        {
            List<string> listjob;
            bool exists = allowed.TryGetValue(job,out listjob);
            if (!exists) return false;
            if (listjob.Contains(grade)) return true;
            return false;
        }

        public void       setMarkerType(MarkerType result) => this.type = result;
        public MarkerType getMarkerType() => this.type;

        public void setDistance(int result) => this.distance = result;
        public int  getDistance() => this.distance;

        public void drawMarker() => World.DrawMarker(this.type, this.pos, Vector3.Zero, Vector3.Zero, this.scale, this.color);
    }
}