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

#Preparing input from dynamo to revit
elements = UnwrapElement(IN[0])

#a list to output the things
results = []

#Make a filter to apply to the method
filter = ElementCategoryFilter(BuiltInCategory.OST_Doors)

#work through our element list
for e in elements:
	dependentElements = [] #declare list in here to group the results by the host wall
	for i in e.GetDependentElements(filter): #iterate through the dependent elements
		dependentElements.append(doc.GetElement(i)) #add the elements to the list
	results.append(dependentElements) #add the list of elements to the output list

#return the result
OUT = results