﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using InfoAnalySystem.Utils;
using InfoAnalySystem.PO;
using Newtonsoft.Json;

namespace InfoAnalySystem.Forms {
    public partial class EventTimeBarForm : Form {

        public EventTimeBarForm() {
            InitializeComponent();

            // 替换html文件
            //var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            //using (var htmlFileR = File.OpenRead(htmlPath + "index.html")) {
            //    htmlDoc.Load(htmlFileR);
            //    htmlDoc.DocumentNode.SelectSingleNode("//*[@class='container']/h1").InnerHtml = "nice!";
            //}
            //File.Delete(htmlPath + "index_fill.html");
            //using (var htmlFileW = File.OpenWrite(htmlPath + "index_fill.html")) {
            //    htmlDoc.Save(htmlFileW);
            //}

            // 载入网页
            this.webKitBrowser1.Navigate(Const.htmlPath + @"EventTimeBar\index.html");
            TCPHelper.responceFuncDict.Add("/eventTimeBar/getTopicList", getTopicList);
            TCPHelper.responceFuncDict.Add("/eventTimeBar/getEventsByTopic", getEventsByTopic);
        }

        private string getTopicList(Dictionary<string, string> paramDict) {
            var topicList = DBHelper.db.Queryable<Event>()
                .GroupBy(it => it.topic)
                .Select(it => it.topic).ToList();
            return JsonConvert.SerializeObject(topicList);
        }

        private string getEventsByTopic(Dictionary<string, string> paramDict) {
            if (!paramDict.ContainsKey("topic"))
                return "";
            var topic = paramDict["topic"];
            var eventList = DBHelper.db.Queryable<Event>()
                .Where(it => it.topic == topic)
                .OrderBy(it => it.time).ToList();
            var timeEventDict = new Dictionary<string, List<Event>>();
            foreach(var event_ in eventList) {
                var eventTime = event_.time.ToString("yyyy年MM月dd日");
                if (!timeEventDict.ContainsKey(eventTime)) {
                    var timeEventList = new List<Event>();
                    timeEventList.Add(event_);
                    timeEventDict.Add(eventTime, timeEventList);
                }else {
                    timeEventDict[eventTime].Add(event_);
                }
            }
            return JsonConvert.SerializeObject(timeEventDict);

        }


    }
}
