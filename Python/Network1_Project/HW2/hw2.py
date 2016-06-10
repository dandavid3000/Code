__author__ = 'Dan'
import time
import dryscrape
from threading import Thread
import os.path

def crawling_Amazon():
	# set up a web scraping session
	sess = dryscrape.Session(base_url = 'http://www.amazon.com')
	# we don't need images
	sess.set_attribute('auto_load_images', False)

	print "Logging in to Amazon"
	sess.visit('/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=iphone')
	#sess.render('Amazon.png')
	product = sess.xpath('//div[@class="a-fixed-left-grid-inner"]')
		
	
	if product == None:
		print "Cannot connect to Amazon, check your internet connection"
	if product != None:
		data1=""
		print "Collecting data from Amazon ..."
		for i in product:
			name=i.at_xpath('div/div/a/h2[@class]')
			#print "Name:", name.text()
			data1 = data1 + "Name: "+ name.text() + "\n"
			av=i.at_xpath('div/div/div/div/div[@class]')
			#print "Availablity:", av.text()
			data1 = data1 + "Availability: " + av.text() + "\n"
			price=i.at_xpath('div/div/div/div/a[@class]')
			#print "Price:", price.text()
			data1 = data1 + "Price: " + price.text() + "\n\n"
		print "Writing data down to database ... "
		print data1
		with open ('database.txt', 'a') as f1:
			f1.write(data1)
		

def crawling_BBC():
	# set up a web scraping session
	sess = dryscrape.Session(base_url = 'http://www.bbc.co.uk')
	# we don't need images
	sess.set_attribute('auto_load_images', False)
	print "Logging in to BBC Learning English"
	sess.visit('/learningenglish/english/features/6-minute-english')
	#sess.render('BBCEnglish.png')
	course = sess.xpath('//li[@class="course-content-item active"]')
	course2 = sess.xpath('//div[@class="widget widget-bbcle-coursecontentlist widget-bbcle-coursecontentlist-featured widget-progress-enabled"]')
	#We use course 2 for collecting data from the main lession
	#print course2
	if course == None:
		print "Cannot connect to BBC, check your internet connection"
	if course != None: 
		data2=""
		print "Collecting data from BBC ..."
		for j in course2:
			name=j.at_xpath('div/h2/a[@href]')
			data2 = data2 + "Name: "+name.text()+"\n"
			date=j.at_xpath('div/div/h3')
			data2 = data2 + "Ep/Date: "+date.text()+"\n"
			description=j.at_xpath('div/div/p')
			data2 = data2 + "Description: "+description.text()+"\n\n"
		
		for i in course:
			name=i.at_xpath('div/h2/a[@href]')
			#print "Name:", name.text()
			data2 = data2 + "Name: "+name.text()+"\n"
			date=i.at_xpath('div/div/h3')
			#print "Ep/Date:", date.text()
			data2 = data2 + "Ep/Date: "+date.text()+"\n"
			description=i.at_xpath('div/div/p')
			#print "Description:", description.text()
			data2 = data2 + "Description: "+description.text()+"\n\n"
		print data2
		print "Writing data down to database... "
		with open ('database.txt', 'a') as f2:
			f2.write(data2)
	

#crawling_Amazon()
#crawling_BBC()

threads=[]
t1 = Thread(target=crawling_Amazon)
t2 = Thread(target=crawling_BBC)

t1.start()
time.sleep(2)
t2.start()
threads.append(t1)
threads.append(t2)

[t.join() for t in threads]


