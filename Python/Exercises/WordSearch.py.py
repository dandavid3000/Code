#!/usr/bin/python
# -*- coding: UTF-8 -*-

import re

def CountOccurencesInText(word,text):
	#', and '[abcxyz]' should be considered
    pattern = "(?<![a-z])((?<!')|(?<=''))" + word + "(?![a-z])((?!')|(?=''))"
    return len(re.findall(pattern, text, re.IGNORECASE))

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
    
    
