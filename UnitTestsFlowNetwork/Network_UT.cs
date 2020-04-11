using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestsFlowNetwork
{
    [TestClass]
    public class Network_UT
    {
        [TestMethod]
        public void AddComponent_FindComponent()
        {
            Point myPoint = new Point(10, 10);
            Network myNetwork = new Network("My network");
            Splitter mySplitter = new Splitter(myPoint);
            myNetwork.addComponent(mySplitter);
            Assert.AreEqual(mySplitter, myNetwork.findComponent(myPoint));
        }

        [TestMethod]
        public void AddComponent_RmvComponent()
        {
            Network myNetwork = new Network("My network");
            Splitter mySplitter = new Splitter(new Point(10, 10));
            myNetwork.addComponent(mySplitter);
            Assert.AreEqual(true, myNetwork.removeComponent(mySplitter));
        }

   /*     [TestMethod]
        public void RemovePipeline()
        {
            Network myNetwork = new Network("My network");
            PumpSink myPump = new PumpSink(20,20,false,new Point(10,10));
            PumpSink mySink = new PumpSink(0, 20, true, new Point(10, 200));
            List<Point> listPoints = new List<Point>();
            listPoints.Add(new Point(21, 21));
            listPoints.Add(new Point(151, 121));
            listPoints.Add(new Point(11, 201));
            List<Point> listOfOnePoint = new List<Point>();
            listOfOnePoint.Add(new Point(151, 121));
            Pipeline myPipeline = new Pipeline(myPump, mySink,listOfOnePoint,20);
            myNetwork.addPipeline(listPoints,20);
            Assert.AreEqual(myNetwork.removePipeline(myNetwork.findPipeline(new Point(151, 121))), true);
        }*/

        [TestMethod]
        public void SaveLoadNetwork()
        {
            Network network = new Network("My Network");
            PumpSink newPump = new PumpSink(10, 20, false, new Point(20, 20));
            network.addComponent(newPump);

            FileHelper fh = new FileHelper();
            fh.FileName = AppDomain.CurrentDomain.BaseDirectory + "\\myNetwork2.bin";

            fh.saveToFile(network);

            Network loadedNetwork = fh.loadFromFile();
            PumpSink foundPump = (PumpSink)loadedNetwork.findComponent(new Point(20, 20));

            Assert.AreEqual(foundPump.CurrentFlow, newPump.CurrentFlow);
        }
    }
}
