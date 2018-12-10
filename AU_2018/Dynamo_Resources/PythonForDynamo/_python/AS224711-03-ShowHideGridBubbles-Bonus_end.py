# Python template for Revit
import clr

clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *
from Autodesk.Revit.DB.Structure import *

clr.AddReference('RevitAPIUI')
from Autodesk.Revit.UI import *

clr.AddReference('System')
from System.Collections.Generic import List

clr.AddReference('RevitNodes')
import Revit
clr.ImportExtensions(Revit.GeometryConversion)
clr.ImportExtensions(Revit.Elements)

clr.AddReference('RevitServices')
import RevitServices
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

doc = DocumentManager.Instance.CurrentDBDocument
uidoc=DocumentManager.Instance.CurrentUIApplication.ActiveUIDocument

activeView = doc.ActiveView

#Preparing input from dynamo to revit
elements = UnwrapElement(IN[0])
toggle = IN[1]

#We need a transaction because we are making a change to the Revit model
TransactionManager.Instance.EnsureInTransaction(doc)

for i in elements:
	if toggle == True: #allows us to swap between the options
		i.ShowBubbleInView(DatumEnds.End1,activeView) #Show end 1 in the view
		i.HideBubbleInView(DatumEnds.End0,activeView) # hide end 0 in the view
	else:
		i.ShowBubbleInView(DatumEnds.End0,activeView) #Show end 0 in the view
		i.HideBubbleInView(DatumEnds.End1,activeView) # hide end 1 in the view

TransactionManager.Instance.TransactionTaskDone()

OUT = elements