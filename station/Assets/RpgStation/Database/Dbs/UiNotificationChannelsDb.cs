﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Station
{
    [CreateAssetMenu]
    public class UiNotificationChannelsDb : DictGenericDatabase<UiChannelModel>
    {
        [Serializable] public class LocalDictionary : SerializableDictionary<string, UiChannelModel> {}
        [SerializeField] private LocalDictionary _db = new LocalDictionary();
  
        public override IDictionary<string, UiChannelModel> Db
        {
            get => _db;
            set => _db.CopyFrom (value);
        }


        public override string[] ListEntryNames()
        {
            return _db.Select(entry => entry.Value.Name).ToArray();
        }
        
        public override string ObjectName()
        {
            return "Channel";
        }

        public UiChannelModel GetChannelByName(string channelName)
        {
            foreach (var model in _db.Values)
            {
                if (model.Name == channelName)
                    return model;
            }
            return null;
        }
    }
}

