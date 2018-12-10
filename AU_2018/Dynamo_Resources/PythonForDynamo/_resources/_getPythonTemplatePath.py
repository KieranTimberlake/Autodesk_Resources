import sys

pyt_path = r'C:\Program Files (x86)\IronPython 2.7\Lib'
sys.path.append(pyt_path)

import os

username = os.environ.get( "USERNAME" )

OUT = "C:\\Users\\" + username + "\\AppData\\Roaming\\Dynamo\\Dynamo Revit\\2.0\\PythonTemplate.py"