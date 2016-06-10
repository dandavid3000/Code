__author__ = 'danvo'

import os
import sys
data = sys.argv[1]

#print data

command = 'tshark -r '+ data +' -T fields -e ip.src -e tcp.options.timestamp.tsval | sort > result'
os.system(command)

with open('result') as f:
    content = f.readlines()

#Declare a result array to store IP and Timestamp
res=[]

#Set values to arrays
for i in content:
    a = i.split()
    res.append(a)

for i in range(len(res)-1):
    if res[i][0] == res[i+1][0]:
        thres = abs(int(res[i+1][1]) - int(res[i][1]))
        if thres > 100000:
            print res[i][0]


#  print (res[i][j])
#       cong don vao delta
#       so sanh neu giong lay sau tru truoc
#
#       neu so sanh khac, thi ngung
#       tinh cai delta khac

#resTimestamp.append(a[1])
#Because we sort all IP at the beginning so, I use a temp IP variable
#tempIP=''

#for i in range(len(resIP)-1):
#    if resIP[i] != resIP[i+1]:
#        print resIP[i]
#        print resIP[i+1]




# f = open('resIP','w')
# for i in resIP:
#     f.write(i + '\n')
# f.close()
#
# f = open('resTimestamp','w')
# for i in resTimestamp:
#     f.write(i + '\n')
# f.close()



