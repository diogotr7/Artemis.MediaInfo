﻿using System.Collections.Generic;
using Windows.Media;
using Windows.Media.Control;
using Artemis.Core;
using Artemis.Core.ColorScience;
using Artemis.Core.Modules;
using WindowsMediaController;

namespace Artemis.MediaInfo.DataModels
{
    public class MediaInfoDataModel : DataModel
    {
        [DataModelProperty(Name = "A media is being reported")]
        public bool HasMedia { get; set; }
        
        [DataModelProperty(Name = "A media is playing")]
        public bool MediaPlaying { get; set; }
        
        [DataModelProperty(Name = "Next media can be played")]
        public bool HasNextMedia { get; set; }
        
        [DataModelProperty(Name = "Previous media can be played")]
        public bool HasPreviousMedia { get; set; }
        
        [DataModelProperty(Name = "Latest updated media state",
            Description = " Note that there may be other media sessions. " +
                          "Other values become true when any of the sessions meet the conditions.")]
        public GlobalSystemMediaTransportControlsSessionPlaybackStatus MediaState { get; set; }
        
        
        [DataModelProperty(Name = "Has Art",
            Description = "If the media app provided an art.")]
        public bool HasArt { get; set; }

        public ColorSwatch ArtColors { get; set; }
        
        public string SessionName { get; set; }

        public DataModelEvent<MediaChangedEventArgs> MediaChanged { get; } = new();
        public HashSet<MediaManager.MediaSession> MediaSessions { get; set; }
    }

    public class MediaChangedEventArgs : DataModelEventArgs
    {
        public string SessionId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public MediaPlaybackType MediaType { get; set; }
        public bool HasArt { get; set; }
    }
}
