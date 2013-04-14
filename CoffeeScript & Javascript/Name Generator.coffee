build_list = (big_list) ->
  words = big_list.split("\n")
  window.word_list[0] = []
  name_list = []
  word_list_index = 0
  for word of words
    switch words[word]
      when "----"
        wcount = word
        word_list[word_list_index] = []
    word_list[word_list_index].push words[word]
    console.log wcount
 
$.get "./name-list.txt", (data) ->
  build_list data
  $("div#noun_name0").text "Why not start below?"

$("div#new_name").live "click", (event) ->
  $("div#noun_name0").text generate_noun_name()
  $("a#tweet").each ->
    $(this).attr "href", ("http://twitter.com/share?url=http://somesailboat.com/&text=I made \"" + $("div#noun_name0").text() + "\" with the homegrown name generator!")
      
generate_noun_name = ->
  first_word = window.word_list[0][Math.floor(Math.random() * window.word_list[0].length)]
  second_word = ""
  third_word = ""
  
  bad_match_list = new Array()
  allow_similar_matches = not $("#similar").is(":checked")
  unless first_word.indexOf("^") is -1
    bad_match_list = first_word.split("^")[1].split("|")  unless allow_similar_matches
    first_word = first_word.split("^")[0]
  
  second_word_bad = true
  while second_word_bad
    second_word = window.word_list[1][Math.floor(Math.random() * window.word_list[1].length)]
    unless second_word.indexOf("^") is -1
      bad_match_list.concat second_word.split("^")[1].split("|")  unless allow_similar_matches
      second_word = second_word.split("^")[0]
    continue  if second_word is first_word
    continue  unless $.inArray(second_word, bad_match_list) is -1
    second_word_bad = false
  
  third_word_bad = true
  while third_word_bad
    third_word = window.word_list[2][Math.floor(Math.random() * window.word_list[2].length)]
    unless third_word.indexOf("^") is -1
      bad_match_list.concat third_word.split("^")[1].split("|")  unless allow_similar_matches
      third_word = second_word.split("^")[0]
    continue  if third_word is first_word or third_word is second_word
    continue  unless $.inArray(third_word, bad_match_list) is -1
    third_word_bad = false
  
  first_word + " | " + second_word + " | " + third_word
  
addLoadEvent = (func) ->
  oldonload = window.onload
  unless typeof window.onload is "function"
    window.onload = func
  else
    window.onload = ->
      oldonload()  if oldonload
      func()


word_list = new Array(3)