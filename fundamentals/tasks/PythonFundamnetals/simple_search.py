"""
    Simple Searching
    Starting with the code snippet below, write a regex that will match:

    All words that contain a “v”
    All words that contain a double-“s”
    All words that end with an “e”
    All words that contain an “b”, any character, then another “b”
    All words that contain an “b”, at least one character, then another “b”
    All words that contain an “b”, any number of characters (including zero), then another “b”
    All words that include all five vowels in order
    All words that only use the letters in “regular expression” (each letter can appear any number of times)
    All words that contain a double letter
    
    For this assignment, you might find an online regex tester, such as Pythex (http://pythex.org/?regex=.&test_string=aimlessness assassin baby beekeeper belladonna cannonball crybaby denver embraceable facetious flashbulb gaslight hobgoblin iconoclast issue kebab kilo laundered mattress millennia natural obsessive paranoia queen rabble reabsorb sacrilegious schoolroom tabby tabloid unbearable union videotape&ignorecase=0&multiline=1&dotall=0&verbose=0), to be helpful.
""" 


import re  # import python regex module

def get_matching_words(regex):
 words = ["aimlessness", "assassin", "baby", "beekeeper", "belladonna", "cannonball", "crybaby", "denver", "embraceable", "facetious", "flashbulb",
          "gaslight", "hobgoblin", "iconoclast", "issue", "kebab", "kilo", "laundered", "mattress", "millennia", "natural", "obsessive", "paranoia", "queen", "rabble",
          "reabsorb", "sacrilegious", "schoolroom", "tabby", "tabloid", "unbearable", "union", "videotape","", "1","12","11333"]
 matches = []
 for word in words:
 	if re.search(regex,word):
 		matches.append(word)
 return matches
 

print get_matching_words(r"v")
print get_matching_words(r"ss")
print get_matching_words(r"e$")
print get_matching_words(r"b.b")
print get_matching_words(r"b.+b")
print get_matching_words(r"b.*b")
print get_matching_words(r"[^aeiou]*a[^aeiou]*e[^aeiou]*i[^aeiou]*o[^aeiou]*u[^aeiou]*")
print get_matching_words(r"a|b|c+")
print get_matching_words(r"(.)\1")
print get_matching_words(r'(?P<word>\d+?)')
