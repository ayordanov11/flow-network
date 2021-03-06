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
public class AdjustableSplitter : Splitter
{
    // ---------------------- Fields ----------------------

    private int topPercentage;

    // ------------------- Constructors -------------------

    public AdjustableSplitter(int topPercentage, Point location) : base(location)
    {
        this.topPercentage = topPercentage;
        Position = location;
    }

    // -------------------- Properties --------------------

    public int TopPercentage { get { return topPercentage; } }

    // --------------------- Methods ----------------------

    /// <summary>
    /// This method changes the topPercentage value and re-calculates the bottom output accordingly. 
    /// After that, it invokes the recalculateFlow method that it inherits from Splitter.
    /// </summary>
    /// <param name="newPercentage">Integer number between 0 and 100</param>
    public void changeSplitterPercentage(int newPercentage)
	{
        topPercentage = newPercentage;

        OutflowUp = InFlow / 100 * topPercentage;
        OutflowBottom = InFlow - OutflowUp;
	}
}

