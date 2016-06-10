__author__ = 'danvo'

import os
import magic
import mimetypes
import sys

if len(sys.argv) == 2:
    dirt = sys.argv[1]
    m = mimetypes.MimeTypes()

if len(sys.argv) == 3:
    dirt = sys.argv[1]
    lib = sys.argv[2]
    m = mimetypes.MimeTypes()
    m.read(lib)

#Check whether dir exists or not
if (os.path.isdir(dirt)):
    magicMime = magic.Magic(mime=True)

    listFile = []

    #Get absolute paths
    for path, subdirs, files in os.walk(dirt):
        for name in files:
             listFile.append(os.path.join(path, name))

    #print listFile
    for i in listFile:

        mm = (magicMime.from_file(i))
        mt = m.guess_type(i)

        # print ("Magic -"+ str(mm))
        # print ("Mime - "+ str(mt[0]))

        # if mm == mt[0]:
        #     print (i + "- Normal file")
        if mm != mt[0]:
            print (i + "- Camouflaged file")




