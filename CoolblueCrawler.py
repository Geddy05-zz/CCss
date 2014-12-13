try:
    import urllib.request as urllib2
except:
    import urllib2
from bs4 import BeautifulSoup
from py2neo import node, neo4j

# product overview urls
moederbord="http://www.computerstore.nl/category/208983/moederborden.html?items=80","Moederbord"
processoren="http://www.computerstore.nl/category/208406/processoren.html?items=44","Processor"
Ram="http://www.computerstore.nl/category/101157/ram-geheugen.html?items=97","Geheugen"
videokaarten="http://www.computerstore.nl/category/202958/videokaarten.html?items=59","Grafischekaart"
behuizing="http://www.computerstore.nl/category/211985/computerbehuizingen.html?items=35","Behuizing"
voeding="http://www.computerstore.nl/category/202961/pc-voedingen.html?items=27","Voeding"
koeler="http://www.computerstore.nl/category/208476/processorkoelers.html?items=21","Koeler"
hardeschijven="http://www.computerstore.nl/category/100852/interne-harde-schijven.html?items=70","Hardeschijf"
ssd="http://www.computerstore.nl/category/182669/solid-state-drives-ssd.html","Hardeschijf"
geluidskaart="http://www.computerstore.nl/category/212754/geluidskaarten.html?items=6","Geluidskaart"
pci="http://www.computerstore.nl/category/212755/pci-kaarten.html","Netwerk"
branders="http://www.computerstore.nl/category/101761/branders-dvd-blu-ray.html?items=13","Optischedrives"


# 2 arrays voor de urls en de label namen.
urlsOverview = []
namesOverview = []

#create a connecting with the database on our server
print ("Connecting with database")
graph_db = neo4j.GraphDatabaseService("http://145.24.222.101:8001/db/data/")
batch = neo4j.WriteBatch(graph_db)


#The crawl function
def getInfo():
    i=0
    # for each url in the urloverview the crawler load de page and start searching for the div's we ask for.
    print ("Connecting www.computerstore.nl")
    for url in urlsOverview:
        webpage = urllib2.urlopen(url)
        soup = BeautifulSoup(webpage)

        #select all items we want in our database
        for item in soup.findAll("li", {"class" : "product-list-columns--item product-list-item"}):
            producturlinput = item.find("a",{"class" : "product-list-item--image-link"}).get('href')
            producturl = "http://www.computerstore.nl/"+producturlinput

            #open the detail page with the information we need
            detailpagina = urllib2.urlopen(producturl)
            detailsoup = BeautifulSoup(detailpagina)
            name =str(detailsoup.find("span", {"itemprop": "name"}).getText()).strip('\t\r\n\xa0')
            price = str(detailsoup.find("span",{"class":"price-amount"}).getText()).replace(u"\u20ac", '').replace(" ", '').strip('\t\r\n\xa0')

            # the item above we use as properties in the neo4j database.
            # For creating a node we need to create a dictonaire below.
            dict = {"Name":name, "ProductUrl": producturl,"Price":price}

            for table in detailsoup.findAll("table", {"class": "table table_spectable roundedcorners"}):

                for rownames in table.findAll("tr"):
                    try:
                        rname = str(rownames.find("td" , {"class":"table_spectable_spec"}).getText()).replace(":","").strip('\t\r\n\xa0').lower()
                        try:
                            # if a span tag is in the td this will be the text we needs
                            rname = str(rownames.find("span" , {"class":"table_spectable_spec_titletext"}).getText()).replace(":","").strip('\t\r\n\xa0').lower()
                        except:
                            # if there is no span tag in the td we need the text from te td tag
                            rname = str(rownames.find("td" , {"class":"table_spectable_spec"}).getText()).replace(":","").strip('\t\r\n\xa0').lower()


                    except:
                        rname=""
                    try:
                        rinfo = str(rownames.find("td" , {"class":"table_spectable_specdescription table_cell_last"}).getText()).replace(":","").strip('\t\r\n\xa0').lower()

                        # remove all not useful characters like &nbsp;
                        rinfoParsingStorage=''
                        for letter in rinfo:
                            if letter.isalpha() or letter.isdigit():
                                rinfoParsingStorage += letter
                                rinfo=rinfoParsingStorage

                    except:
                        rinfo=""

                    # remove all not useful characters like &nbsp;
                    if rname != "" or rinfo !="":
                        dicttemp = {rname:rinfo}
                        dict.update(dicttemp)

            #Creating the node
            newNode = batch.create(node((dict)))

            #add label to the node
            label= str(namesOverview[i])
            batch.add_labels(newNode,label)


        percentage = (100/len(urlsOverview) *(i+1))
        procces = "Percentage : "+str("%.2f" % percentage)+"% done"
        print (procces)
        i=i+1

# Fill the urlsoverview and take the key  from the dictionary
def createUrls():
    urlsOverview.append(moederbord[0])
    urlsOverview.append(processoren[0])
    urlsOverview.append(Ram[0])
    urlsOverview.append(videokaarten[0])
    urlsOverview.append(behuizing[0])
    urlsOverview.append(voeding[0])
    urlsOverview.append(koeler[0])
    urlsOverview.append(hardeschijven[0])
    urlsOverview.append(ssd[0])
    urlsOverview.append(geluidskaart[0])
    urlsOverview.append(pci[0])
    urlsOverview.append(branders[0])

# Fill the nameOverview and take the value  from the dictionary
def createLabelNames():
    namesOverview.append(moederbord[1])
    namesOverview.append(processoren[1])
    namesOverview.append(Ram[1])
    namesOverview.append(videokaarten[1])
    namesOverview.append(behuizing[1])
    namesOverview.append(voeding[1])
    namesOverview.append(koeler[1])
    namesOverview.append(hardeschijven[1])
    namesOverview.append(ssd[1])
    namesOverview.append(geluidskaart[1])
    namesOverview.append(pci[1])
    namesOverview.append(branders[1])

# call the functions for executing. First we need te make te url/name overview before we running the real crawl function.
# when the craw(get info()) function is finished the batch will be submit and pushed to the database
createUrls()
createLabelNames()
getInfo()
# Send the created nodes to the neo4j database
batch.submit()

