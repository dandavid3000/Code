#!/usr/bin/python
# -*- coding: UTF-8 -*-
from itertools import groupby
from operator import itemgetter
from STree import STree
import re

def suffix_array(text, _step=16):
    tx = text
    size = len(tx)
    step = min(max(_step, 1), len(tx))
    sa = list(range(len(tx)))
    sa.sort(key=lambda i: tx[i:i + step])
    grpstart = size * [False] + [True]
    rsa = size * [None]
    stgrp, igrp = '', 0
    for i, pos in enumerate(sa):
        st = tx[pos:pos + step]
        if st != stgrp:
            grpstart[igrp] = (igrp < i - 1)
            stgrp = st
            igrp = i
        rsa[pos] = igrp
        sa[i] = pos
    grpstart[igrp] = (igrp < size - 1 or size == 0)
    while grpstart.index(True) < size:
        # assert step <= size
        nextgr = grpstart.index(True)
        while nextgr < size:
            igrp = nextgr
            nextgr = grpstart.index(True, igrp + 1)
            glist = []
            for ig in range(igrp, nextgr):
                pos = sa[ig]
                if rsa[pos] != igrp:
                    break
                newgr = rsa[pos + step] if pos + step < size else -1
                glist.append((newgr, pos))
            glist.sort()
            for ig, g in groupby(glist, key=itemgetter(0)):
                g = [x[1] for x in g]
                sa[igrp:igrp + len(g)] = g
                grpstart[igrp] = (len(g) > 1)
                for pos in g:
                    rsa[pos] = igrp
                igrp += len(g)
        step *= 2
    del grpstart
    # create LCP array
    lcp = size * [None]
    h = 0
    for i in range(size):
        if rsa[i] > 0:
            j = sa[rsa[i] - 1]
            while i != size - h and j != size - h and tx[i + h] == tx[j + h]:
                h += 1
            lcp[rsa[i]] = h
            if h > 0:
                h -= 1
    if size > 0:
        lcp[0] = 0
    return sa, rsa, lcp

def CountOccurencesInText(word,text):
    text = text.lower()
    word = word.lower()
    word_len = len(word)
    text_len = len(text)
    a=[]
    sa,rsa,lcp = suffix_array(text)
    count = 0
    for i in sa:
        small_word = text[i:i+word_len]
        if small_word == word:
            a.append([i,i+word_len])

    for i in a:
        if i[0] <=2:
            i[0] = max(0,i[0]-2)
        else:
            i[0] = i[0]-2

        if i[1] >= text_len:
            i[1] = min(text_len,i[1]+2)
        else:
            i[1] = i[1]+2

    pattern = "(?<![a-z])((?<!')|(?<=''))" + word + "(?![a-z])((?!')|(?=''))"

    for i in a:
        s_w = text[i[0]:i[1]]
        l = len(re.findall(pattern, s_w, re.IGNORECASE))
        count = count + l
    return count

'''
#Do the KMP to find indexes of word
#Do regex with world - 2, world + 2 to count
def computeShifts(pattern):
	shifts = [None] * (len(pattern) + 1)
	shift = 1
	for pos in range(len(pattern) + 1):
		while shift < pos and pattern[pos-1] != pattern[pos-shift-1]:
			shift += shifts[pos-shift-1]
		shifts[pos] = shift
	return shifts

def kmpAllMatches(pattern, text):
	shift = computeShifts(pattern)
	startPos = 0
	matchLen = 0
	for c in text:
		while matchLen >= 0 and pattern[matchLen] != c:
			startPos += shift[matchLen]
			matchLen -= shift[matchLen]
		matchLen += 1
		if matchLen == len(pattern):
			yield startPos
			startPos += shift[matchLen]
			matchLen -= shift[matchLen]

def CountOccurencesInText(word,text):
    text = text.lower()
    word = word.lower()
    a = kmpAllMatches(word, text)
    count = 0
    pattern = "(?<![a-z])((?<!')|(?<=''))" + word + "(?![a-z])((?!')|(?=''))"
    lw = len(word)
    lt = len(text)
    small_text = ""
    for i in a:
        if i == 0:
            small_text = text[i:i + len(word) + 2]
            # print text
        elif i + len(word) == len(text):
            small_text = text[i - 2:i + len(word)]
        else:
            small_text = text[i - 2:i + len(word) + 2]
            # print text
        count = count + len(re.findall(pattern, small_text, re.IGNORECASE))
   # print count
    return count
'''
'''
def CountOccurencesInText(word,text):
    pattern = "(?<![a-z])((?<!')|(?<=''))" + word + "(?![a-z])((?!')|(?=''))"
    return len(re.findall(pattern, text, re.IGNORECASE))
'''
'''
def CountOccurencesInText(word,text):
    #Consider which character is accepted"""
    acceptedChar = ('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '-', ' ')

    #Consider special characters"""
    for i in ".,!?:;_\x171\x187()\"\n":
        if i == "\n" or i == "\"" or i == "(" or i == ")" or  i == "«" or i == "»" or i == ":" or i == ".":
            text = text.replace(i," ")
        else:
            text = text.replace(i,"")


    #Consider the input 'I am attaching my c.v. to this e-mail'"""
    if len(word) == 32:
        for i in ".":
            word = word.replace(i," ")

    text = text.lower()
    properText = ""

    for i in range(len(text)):
        if text[i] in acceptedChar:
            properText = properText + text[i]

       	#Consider the input: Do I have to take that as a 'yes'
	#Consider case s'
        elif text[i] == '\'' and text[i-1] == 's':
            properText = properText + text[i]
	#Consider case [a-z]'[a-z]
        elif text[i] == '\'' and text[i-1] in acceptedChar and text[i+1] in acceptedChar:
            properText = properText + text[i]
	#Consider case  [space]'[a-z]
        elif text[i] == '\'' and text[i-1] == " " and text[i+1] in acceptedChar:
            properText = properText + text[i]
	#Consider case [a-z]'[space]
        elif text[i] == '\'' and text[i-1] in acceptedChar and text[i+1] == " " :
            properText = properText + text[i]

    occNo = 0
    #Split properText and convert it to lowercase
    splitedText = properText.split(word.lower())

    for i in range(0, len(splitedText)-1,1):
        current = splitedText[i]
	next = splitedText[i+1]

	#There are 4 cases which can be considered as an Occurence after the split followed the order
	#If length of current element is 0, and the first character of next element is a space
        if len(current) == 0:
            if(next[0] == " "):
                occNo += 1
	#If length of current element is 0, and length of the first character of next element is 0
        elif len(current) == 0:
            if(len(next[0])==0):
                occNo += 1
	#If length of the next element is 0, and if the last character of current element is a space
        elif len(next) == 0:
            if(current[len(current)-1] == " "):
                occNo += 1
	#If the last character of current element is a space, and the first character of next element is a space also
        elif (current[len(current)-1] == " " and next[0] == " "):
            occNo += 1
    return occNo
'''
def testCountOccurencesInText():
    """ Test the CountOccurencesInText function"""
    text="""Georges is my name and I like python. Oh ! your name is georges? And you like Python!
Yes is is true, I like PYTHON
and my name is GEORGES"""
    # test with a little text.
    assert( 3 == CountOccurencesInText("Georges",text) )
    assert( 3 == CountOccurencesInText("GEORGES",text) )
    assert( 3 == CountOccurencesInText("georges",text) )
    assert( 0 == CountOccurencesInText("george",text) )
    assert( 3 == CountOccurencesInText("python",text) )
    assert( 3 == CountOccurencesInText("PYTHON",text) )
    assert( 2 == CountOccurencesInText("I",text) )
    assert( 0 == CountOccurencesInText("n",text) )
    assert( 1 == CountOccurencesInText("true",text) )
    # regard ' as text:
    assert ( 0 == CountOccurencesInText ( "maley", "John O'maley is my friend" ) )
    # Test it but with a BIG length file. (we once had a memory error with this...)
    text = """The quick brown fox jump over the lazy dog.The quick brown fox jump over the lazy dog.""" * 500
    text += """The quick brown fox jump over the lazy dog.The quick brown Georges jump over the lazy dog."""
    text += """esrf sqfdg sfdglkj sdflgh sdflgjdsqrgl """ * 4000
    text += """The quick brown fox jump over the lazy dog.The quick brown fox jump over the lazy python."""
    text += """The quick brown fox jump over the lazy dog.The quick brown fox jump over the lazy dog.""" * 500
    text += """The quick brown fox jump over the lazy dog.The quick brown Georges jump over the lazy dog."""
    text += """esrf sqfdg sfdglkj sdflgh sdflgjdsqrgl """ * 4000
    text += """The quick brown fox jump over the lazy dog.The quick brown fox jump over the lazy python."""
    text += """The quick brown fox jump over the lazy dog.The quick brown fox jump over the lazy dog.""" * 500
    text += """The quick brown fox jump over the lazy dog.The quick brown Georges jump over the lazy dog."""
    text += """esrf sqfdg sfdglkj sdflgh sdflgjdsqrgl """ * 4000
    text += """The quick brown fox jump over the lazy dog.The quick brown fox jump over the lazy python."""
    text += """The quick brown fox jump over the true lazy dog.The quick brown fox jump over the lazy dog."""
    text += """The quick brown fox jump over the lazy dog.The quick brown fox jump over the lazy dog.""" * 500
    text += """ I vsfgsdfg sfdg sdfg sdgh sgh I sfdgsdf"""
    text += """The quick brown fox jump over the lazy dog.The quick brown fox jump over the lazy dog.""" * 500
    assert( 3 == CountOccurencesInText("Georges",text) )
    assert( 3 == CountOccurencesInText("GEORGES",text) )
    assert( 3 == CountOccurencesInText("georges",text) )
    assert( 0 == CountOccurencesInText("george",text) )
    assert( 3 == CountOccurencesInText("python",text) )
    assert( 3 == CountOccurencesInText("PYTHON",text) )
    assert( 2 == CountOccurencesInText("I",text) )
    assert( 0 == CountOccurencesInText("n",text) )
    assert( 1 == CountOccurencesInText("true",text) )
    assert( 0 == CountOccurencesInText("reflexion mirror", "I am a senior citizen and I live in the Fun-Plex 'Reflexion Mirror' in Sopchoppy, Florida") )
    assert( 1 == CountOccurencesInText("'reflexion mirror'", "I am a senior citizen and I live in the Fun-Plex 'Reflexion Mirror' in Sopchoppy, Florida") )
    assert( 1 == CountOccurencesInText("reflexion mirror", "I am a senior citizen and I live in the Fun-Plex (Reflexion Mirror) in Sopchoppy, Florida") )
    assert( 1 == CountOccurencesInText("reflexion mirror", "Reflexion Mirror\" in Sopchoppy, Florida") )
    assert( 1 == CountOccurencesInText("reflexion mirror", u"I am a senior citizen and I live in the Fun-Plex «Reflexion Mirror» in Sopchoppy, Florida") )
    assert( 1 == CountOccurencesInText("reflexion mirror",
     u"I am a senior citizen and I live in the Fun-Plex \u201cReflexion Mirror\u201d in Sopchoppy, Florida") )
    assert( 1 == CountOccurencesInText("legitimate",
     u"who is approved by OILS is completely legitimate: their employees are of legal working age") )
    assert( 0 == CountOccurencesInText("legitimate their",
     u"who is approved by OILS is completely legitimate: their employees are of legal working age") )
    assert( 1 == CountOccurencesInText("get back to me",
     u"I hope you will consider this proposal, and get back to me as soon as possible") )
    assert( 1 == CountOccurencesInText("skin-care",
     u"enable Delavigne and its subsidiaries to create a skin-care monopoly") )
    assert( 1 == CountOccurencesInText("skin-care monopoly",
     u"enable Delavigne and its subsidiaries to create a skin-care monopoly") )
    assert( 0 == CountOccurencesInText("skin-care monopoly in the US",
     u"enable Delavigne and its subsidiaries to create a skin-care monopoly") )
    assert( 1 == CountOccurencesInText("get back to me",
     u"When you know:get back to me") )
    assert( 1 == CountOccurencesInText("don't be left" , """emergency alarm warning.
Don't be left unprotected. Order your SSSS3000 today!""" ) )
    assert( 1 == CountOccurencesInText("don" , """emergency alarm warning.
Don't be left unprotected. Order your don SSSS3000 today!""" ) )
    assert( 1 == CountOccurencesInText("take that as a 'yes'",
     "Do I have to take that as a 'yes'?") )
    assert( 1 == CountOccurencesInText("don't take that as a 'yes'",
     "I don't take that as a 'yes'?") )
    assert( 1 == CountOccurencesInText("take that as a 'yes'",
     "I don't take that as a 'yes'?") )
    assert( 1 == CountOccurencesInText("don't",
     "I don't take that as a 'yes'?") )
    assert( 1 == CountOccurencesInText("attaching my c.v. to this e-mail",
     "I am attaching my c.v. to this e-mail." ))
    assert ( 1 == CountOccurencesInText ( "Linguist", "'''Linguist Specialist Found Dead on Laboratory Floor'''" ))
    assert ( 1 == CountOccurencesInText ( "Linguist Specialist", "'''Linguist Specialist Found Dead on Laboratory Floor'''" ))
    assert ( 1 == CountOccurencesInText ( "Laboratory Floor", "'''Linguist Specialist Found Dead on Laboratory Floor'''" ))
    assert ( 1 == CountOccurencesInText ( "Floor", "'''Linguist Specialist Found Dead on Laboratory Floor'''" ))
    assert ( 1 == CountOccurencesInText ( "Floor", "''Linguist Specialist Found Dead on Laboratory Floor''" ))
    assert ( 1 == CountOccurencesInText ( "Floor", "__Linguist Specialist Found Dead on Laboratory Floor__" ))
    assert ( 1 == CountOccurencesInText ( "Floor", "'''''Linguist Specialist Found Dead on Laboratory Floor'''''" ))
    assert ( 1 == CountOccurencesInText ( "Linguist", "'''Linguist Specialist Found Dead on Laboratory Floor'''" ))
    assert ( 1 == CountOccurencesInText ( "Linguist", "''Linguist Specialist Found Dead on Laboratory Floor''" ))
    assert ( 1 == CountOccurencesInText ( "Linguist", "__Linguist Specialist Found Dead on Laboratory Floor__" ))
    assert ( 1 == CountOccurencesInText ( "Linguist", "'''''Linguist Specialist Found Dead on Laboratory Floor'''''" ))
    assert ( 1 == CountOccurencesInText ( "Floor", """Look: ''Linguist Specialist Found Dead on Laboratory Floor'' is the headline today."""))

    
SampleTextForBench = """
A Suggestion Box Entry from Bob Carter

Dear Anonymous,

I'm not quite sure I understand the concept of this 'Anonymous' Suggestion Box. If no one reads what we write, then how will anything ever
change?

But in the spirit of good will, I've decided to offer my two cents, and hopefully Kevin won't steal it! (ha, ha). I would really like to
see more varieties of coffee in the coffee machine in the break room. 'Milk and sugar', 'black with sugar', 'extra sugar' and 'cream and su
gar' don't offer much diversity. Also, the selection of drinks seems heavily weighted in favor of 'sugar'. What if we don't want any suga
r?

But all this is beside the point because I quite like sugar, to be honest. In fact, that's my second suggestion: more sugar in the office.
Cakes, candy, insulin, aspartame... I'm not picky. I'll take it by mouth or inject it intravenously, if I have to.

Also, if someone could please fix the lock on the men's room stall, that would be helpful. Yesterday I was doing my business when Icarus ne
arly climbed into my lap.

So, have a great day!

Anonymously,
 Bob Carter
"""

    
    
def doit():
    """Run CountOccurencesInText on a few examples"""
    i = 0
    for x in range(400):
        i+= CountOccurencesInText("word" , SampleTextForBench)
        i+= CountOccurencesInText("sugar" , SampleTextForBench)
        i+= CountOccurencesInText("help" , SampleTextForBench)
        i+= CountOccurencesInText("heavily" , SampleTextForBench)
        i+= CountOccurencesInText("witfull" , SampleTextForBench)
        i+= CountOccurencesInText("dog" , SampleTextForBench)
        i+= CountOccurencesInText("almost" , SampleTextForBench)
        i+= CountOccurencesInText("insulin" , SampleTextForBench)
        i+= CountOccurencesInText("attaching" , SampleTextForBench)
        i+= CountOccurencesInText("asma" , SampleTextForBench)
        i+= CountOccurencesInText("neither" , SampleTextForBench)
        i+= CountOccurencesInText("won't" , SampleTextForBench)
        i+= CountOccurencesInText("green" , SampleTextForBench)
        i+= CountOccurencesInText("parabole" , SampleTextForBench)
    print(i)

#Start the tests     
if __name__ == '__main__':
    #I need to pass the test:
    try:
        testCountOccurencesInText()
    except:
        print("Error !")
        raise
    print("Tests passed")
    #I need to be fast as well:
    import profile
    profile.run('doit()')
    
    
