﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

[Serializable]
public class Network
{
    // ----------- fields -----------------
    private string name;
    private List<Component> componentsList;
    private List<Pipeline> pipelineList;

    // ----------- constructor ------------
    public Network(string name)
    {
        this.name = name;
        componentsList = new List<Component>();
        pipelineList = new List<Pipeline>();
    }

    // ------------ properties ------------
    public Pipeline SelectedPipeline { get; set; }
    public Component SelectedComponent { get; set; }
    public List<Component> ComponentsList { get { return componentsList; } }
    
    // ------------ methods ---------------
    public void addComponent(Component theComponent)
    {
        componentsList.Add(theComponent);
    }

    public bool removeComponent(Component theComponent)
    {
        if (theComponent is Merger)
        {
            for (int i = 0; i < 3; i++)
            {
                if (theComponent.PipelineList[i] != null)
                {
                    if (i != 2)
                    {
                        theComponent.PipelineList[i].Connection[0].PipelineList[theComponent.PipelineList[i].ConnectedOutIn[0]] = null;
                        pipelineList.Remove(theComponent.PipelineList[i]);
                    }
                    else
                    {
                        theComponent.PipelineList[i].Connection[1].PipelineList[theComponent.PipelineList[i].ConnectedOutIn[1]] = null;
                        pipelineList.Remove(theComponent.PipelineList[i]);
                    }
                }
            }
        }
        else if (theComponent is Splitter)
        {
            for (int i = 0; i < 3; i++)
            {
                if (theComponent.PipelineList[i] != null)
                {
                    if (i == 0)
                    {
                        theComponent.PipelineList[i].Connection[0].PipelineList[theComponent.PipelineList[i].ConnectedOutIn[0]] = null;
                        pipelineList.Remove(theComponent.PipelineList[i]);
                    }
                    else
                    {
                        theComponent.PipelineList[i].Connection[1].PipelineList[theComponent.PipelineList[i].ConnectedOutIn[1]] = null;
                        pipelineList.Remove(theComponent.PipelineList[i]);
                    }
                }   
            }
        }
        else if (theComponent is PumpSink)
        {
            if (theComponent.PipelineList[0] != null)
            {
                if (((PumpSink)theComponent).IsSink != true)
                {
                    theComponent.PipelineList[0].Connection[1].PipelineList[0] = null;
                    pipelineList.Remove(theComponent.PipelineList[0]);
                }
                else
                {
                    theComponent.PipelineList[0].Connection[0].PipelineList[0] = null;
                    pipelineList.Remove(theComponent.PipelineList[0]);
                }
            }
        }

        //foreach (Pipeline p in theComponent.PipelineList)
          //  removePipeline(p);

        if (componentsList.Remove(theComponent)) return true;
        return false;
    }
    

    public void addPipeline(Component outComponent,Component inComponent, List<Point> inBetweenPoints, int safetyLimit, int[] inOut)
    {
        Component startComp = outComponent;
        Component endComp = inComponent;

        Pipeline newPipeline = new Pipeline(startComp, endComp, inBetweenPoints, safetyLimit, inOut);
        startComp.PipelineList[inOut[0]] = newPipeline;
        endComp.PipelineList[inOut[1]] = newPipeline;
        pipelineList.Add(newPipeline);
        startComp.findSource();
    }
    
    public Pipeline findPipeline(Point location)
    {
        List<Point> thePointList;
        foreach (Pipeline element in pipelineList)
        {
            thePointList = new List<Point>();
            thePointList.Add(element.Connection[0].Position);
            thePointList.AddRange(element.InbetweenPoints);
            thePointList.Add(element.Connection[1].Position);
            for (int i = 0; i<thePointList.Count-1;i++)
            {
                if (thePointList[i].X>thePointList[i+1].X)
                {
                    if (thePointList[i].Y >= thePointList[i + 1].Y)
                    {
                        if ((location.X <= thePointList[i].X && location.X >= thePointList[i + 1].X) &&
                          (location.Y <= thePointList[i].Y && location.Y >= thePointList[i + 1].Y))
                            return element;
                    }
                        else
                    {
                        if ((location.X <= thePointList[i].X && location.X >= thePointList[i + 1].X) &&
                          (location.Y >= thePointList[i].Y && location.Y <= thePointList[i + 1].Y))
                            return element;
                    }
                }
                else
                {
                    if (thePointList[i].Y >= thePointList[i + 1].Y)
                    {
                        if ((location.X >= thePointList[i].X && location.X <= thePointList[i + 1].X) &&
                         (location.Y <= thePointList[i].Y && location.Y >= thePointList[i + 1].Y))
                            return element;
                    }
                    else
                    {
                        if (location.X >= thePointList[i].X && location.X <= thePointList[i + 1].X &&
                         location.Y >= thePointList[i].Y && location.Y <= thePointList[i + 1].Y)
                            return element;
                    }
                }
            }
        }

        return null;
    }
    
    public bool removePipeline(Pipeline thePipeline)
    {
        if (pipelineList.Remove(thePipeline))
        {
            thePipeline.Connection[0].PipelineList[thePipeline.ConnectedOutIn[0]] = null;
            thePipeline.Connection[1].PipelineList[thePipeline.ConnectedOutIn[1]] = null;
            return true;
        }
        else
            return false;
    }

    public Component findComponent(Point location)
    {
        foreach (Component element in componentsList)
        {
            int x = element.Position.X;
            int y = element.Position.Y;
            if (((location.X >= x) && (location.X <= (x + element.PictureSize))) && ((location.Y > y) && (location.Y < (y  + element.PictureSize))))
                return element;
        }
        return null;
    }

    public bool changeCurrentFlow(PumpSink pumpSink, int newFlow)
    {
        if (pumpSink.changeCurrentFlow(newFlow)) return true;
        return false;
    }

    public bool changeMaxFlow(PumpSink pumpSink, int newMaxFlow)
    {
        pumpSink.changeMaxFlow(newMaxFlow);
        return true;
    }

    public void changeSplitterPercentage(AdjustableSplitter adjustableSplitter, int newPercentage)
    {
        adjustableSplitter.changeSplitterPercentage(newPercentage);
    }



    public int checkPipelineOrigin(Point thePoint)
    {
        Component theComponent = findComponent(thePoint);
        if (theComponent == null) return -1;
        if (theComponent is PumpSink)
        {
            // if a component is pumps's  origin method retunrs 0
            if (((PumpSink)theComponent).IsSink == false)
            {
                if (((PumpSink)theComponent).PipelineList[0] == null)
                {
                    return 0;
                }
            }
            return -1;
        }
        else if (theComponent is Splitter || theComponent is AdjustableSplitter)
        {
            // if a component is splitter's top origin method returns 1
            if ((thePoint.X > theComponent.Position.X + theComponent.PictureSize / 2 && thePoint.X <= theComponent.Position.X + theComponent.PictureSize) && (thePoint.Y > theComponent.Position.Y && thePoint.Y < theComponent.Position.Y + theComponent.PictureSize / 2))
            {
                if (((Splitter)theComponent).PipelineList[1] == null)
                    return 1;
                else
                    return -1;
            }
            // if a component is splitter's bottom origin method returns 2
            else if ((thePoint.X > theComponent.Position.X + theComponent.PictureSize / 2 && thePoint.X <= theComponent.Position.X + theComponent.PictureSize) && (thePoint.Y > theComponent.Position.Y + theComponent.PictureSize / 2 && thePoint.Y < theComponent.Position.Y + theComponent.PictureSize))
            {
                if (((Splitter)theComponent).PipelineList[2] == null) return 2;
                else return -1;
            }
        }
        else
        {
            // if a component is a merger's origin method returns 3
            if ((thePoint.X > theComponent.Position.X  + theComponent.PictureSize / 2 && thePoint.X <= theComponent.Position.X + theComponent.PictureSize) && (thePoint.Y > theComponent.Position.Y && thePoint.Y < theComponent.Position.Y + theComponent.PictureSize))
            {
                if (((Merger)theComponent).PipelineList[2] == null) return 2;
                else
                    return -1;
            }
        }
        return -1;
    }

 

    public int checkPipelineEnd(Point thePoint)
    {
        Component theComponent = findComponent(thePoint);
        if (theComponent == null) return -1;
        if (theComponent is PumpSink)
        {
            // if a component is sink's end method returns 0
            if (((PumpSink)theComponent).IsSink == true)
            {
                if (((PumpSink)theComponent).PipelineList[0] == null)
                {
                    return 0;
                }
            }
            return -1;
        }
        else if (theComponent is Splitter || theComponent is AdjustableSplitter)
        {
            // if a component is splitter's end method returns 1
            if ((thePoint.X < (theComponent.PictureSize/2 + theComponent.Position.X) && thePoint.X >= theComponent.Position.X) && (thePoint.Y > theComponent.Position.Y && thePoint.Y < theComponent.Position.Y + theComponent.PictureSize))
            {
                if (((Splitter)theComponent).PipelineList[0] == null)
                    return 0;
                else
                    return -1;
            }
        }
        else
        {
            // if a component is merger ^ end method returns 2
            if ((thePoint.X > theComponent.Position.X && thePoint.X <= theComponent.Position.X + theComponent.PictureSize/2) && (thePoint.Y > theComponent.Position.Y && thePoint.Y < theComponent.Position.Y + theComponent.PictureSize/2))
            {
                if (((Merger)theComponent).PipelineList[0] == null)
                    return 0;
                else
                    return -1;
            }
            // if a component is merger's v end method retunrs 3
            else if ((thePoint.X > theComponent.Position.X && thePoint.X <= theComponent.Position.X + theComponent.PictureSize / 2) && (thePoint.Y > theComponent.Position.Y && thePoint.Y < theComponent.Position.Y + theComponent.PictureSize))
            {
                if (((Merger)theComponent).PipelineList[1] == null)
                    return 1;
                else
                    return -1;
            }
        }
        return -1;
    }

    public bool isOccupied(Point thePoint)
    {
        if (findComponent(thePoint) != null) return false;
        if (findPipeline(thePoint) != null) return false;
        return true;
    }

    public void paint(Graphics gr)
    {
        foreach (Pipeline thePipeline in pipelineList)
        {
            thePipeline.draw(gr);
        }

        foreach (Component theComponent in componentsList)
        {
            if (theComponent == SelectedComponent) gr.DrawRectangle(new Pen(Color.Green,5), theComponent.Position.X,theComponent.Position.Y,theComponent.PictureSize, theComponent.PictureSize);

            theComponent.draw(gr);
        }
    }
}
