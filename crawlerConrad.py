try:
    import urllib.request as urllib2
except:
    import urllib2
from bs4 import BeautifulSoup
from py2neo import node, neo4j


#product urls Optische drives
blurayBranders= "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/drives-branders/interne-blu-ray-branders.html","Optischedrives"
dvdBranders= "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/drives-branders/interne-dvd-branders.html","Optischedrives"
bluraySpeler = "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/drives-branders/interne-blu-ray-spelers.html","Optischedrives"
dvdSpeler = "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/drives-branders/interne-dvd-spelers.html","Optischedrives"

#product urls Harde schijven
hddIdeSsd="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-ide-ssd.html","Hardeschijf"
hddSas ="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-sas-hdd.html","Hardeschijf"
HddSata="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-sata-hdd.html","Hardeschijf"
HddSataSsd="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-sata-ssd.html","Hardeschijf"
hddSsh="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-sshd-hdd.html","Hardeschijf"
hddSasdrie="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/35-sas-hdd.html","Hardeschijf"
hddSataDrie="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/35-sata-hdd.html","Hardeschijf"
hddSshdDrie= "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/35-sshd-hdd.html","Hardeschijf"

#product urls werk geheugen
ddrone="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/intern-geheugen/ddr1-geheugen.html","Geheugen"
ddrTwo="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/intern-geheugen/ddr2-geheugen.html","Geheugen"
ddrThree="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/intern-geheugen/ddr3-geheugen.html","Geheugen"
sdRam= "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/intern-geheugen/sd-ram-geheugen.html","Geheugen"

#product urls moederborden
mbMiniITX="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/mini-itx-moederborden.html","Moederbord"
mbSocket1150="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-1150-moederborden.html","Moederbord"
mbSocket1155="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-1155-moederborden.html","Moederbord"
mbSocket2011="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-2011-intel-moederborden.html","Moederbord"
mbSocket478="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-478-moederborden.html","Moederbord"
mbSocketAM="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-am3-amd-moederborden.html","Moederbord"
mbSocketFM="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-fm2-amd-moederborden.html","Moederbord"

#product urls processoren
processorAMD = "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/amd-socket-am3-cpus.html","Processor"
processor1155="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/intel-socket-1155-cpus.html","Processor"
processor2011="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/intel-socket-2011-cpus.html","Processor"
processorFm1="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/amd-socket-fm1-cpus.html","Processor"
processorFm2="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/amd-socket-fm2-cpus.html","Processor"
processor1150="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/intel-socket-1150-cpus.html","Processor"


#product urls overige producten
geluidskaart="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/multimedia-hardware/geluidskaarten-intern.html","Geluidskaart"
behuizing="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/pc-behuizingen/pc-behuizingen.html","Behuizing"
videokaartAMD="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/videokaarten/videokaarten-amd-chipset.html","Grafischekaart"
videokaartNVIDIA="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/videokaarten/videokaarten-nvidia-chipset.html","Grafischekaart"
voeding="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/voedingen/pc-voeding.html","Voeding"

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
    try:
        print ("Connecting Conrad.nl")
        for url in urlsOverview:
            if i == 0:
                print ("job running")

            webpage = urllib2.urlopen(url)
            soup = BeautifulSoup(webpage)


            for item in soup.findAll("div", {"class" : "c-searchresult-list-item-details-inner"}):
                producturlinput = item.find("a",{"class" : "c-searchresult-list-item-link"}).get('href')
                producturl = "https://www.conrad.nl/"+producturlinput

                detailpagina = urllib2.urlopen(producturl)
                detailsoup = BeautifulSoup(detailpagina)
                name =str(detailsoup.find("h1", {"class": "c-productdetails-title"}).getText())
                price = str(detailsoup.find("div",{"class":"product-price"}).getText()).replace(u"\u20ac", '').replace(" ", '').strip('\t\r\n\xa0')

                # the itema above we use as properties in the neo4j database.
                # For creating a node we need to create a dictonaire below.
                dict = {"Name":name, "ProductUrl": producturl,"Price":price}

                for rownames in detailsoup.findAll("tr"):
                    try:

                        rname = str(rownames.find("td" , {"class": "column-left"}).getText()).replace(":","").split(" ").lower()
                    except:
                        rname="onbekend"
                    try:
                        rinfo = str(rownames.find("td" , {"class":"column-right"}).getText()).replace(":","").strip('\t\r\n\xa0').lower()
                        rinfoParsingStorage=''
                        for letter in rinfo:
                            if letter.isalpha() or letter.isdigit():
                                rinfoParsingStorage += letter

                    except:
                        rinfoParsingStorage = "onbekend"


                    dicttemp = {rname[0]:rinfoParsingStorage}
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
    except:
        print("connection problem")

# Fill the urlsoverview and take the key  from the dictionary
def createUrls():
    urlsOverview.append(blurayBranders[0])
    urlsOverview.append(dvdBranders[0])
    urlsOverview.append(bluraySpeler[0])
    urlsOverview.append(dvdSpeler[0])
    urlsOverview.append(hddIdeSsd[0])
    urlsOverview.append(hddSas[0])
    urlsOverview.append(HddSata[0])
    urlsOverview.append(HddSataSsd[0])
    urlsOverview.append(hddSsh[0])
    urlsOverview.append(hddSasdrie[0])
    urlsOverview.append(hddSataDrie[0])
    urlsOverview.append(hddSshdDrie[0])
    urlsOverview.append(ddrone[0])
    urlsOverview.append(ddrTwo[0])
    urlsOverview.append(ddrThree[0])
    urlsOverview.append(sdRam[0])
    urlsOverview.append(mbMiniITX[0])
    urlsOverview.append(mbSocket1150[0])
    urlsOverview.append(mbSocket1155[0])
    urlsOverview.append(mbSocket2011[0])
    urlsOverview.append(mbSocket478[0])
    urlsOverview.append(mbSocketAM[0])
    urlsOverview.append(mbSocketFM[0])
    urlsOverview.append(geluidskaart[0])
    urlsOverview.append(behuizing[0])
    urlsOverview.append(processorAMD[0])
    urlsOverview.append(processor1155[0])
    urlsOverview.append(processor2011[0])
    urlsOverview.append(processorFm1[0])
    urlsOverview.append(processorFm2[0])
    urlsOverview.append(processor1150[0])
    urlsOverview.append(videokaartAMD[0])
    urlsOverview.append(videokaartNVIDIA[0])
    urlsOverview.append(voeding[0])

# Fill the nameOverview and take the value  from the dictionary
def createLabelNames():
    namesOverview.append(blurayBranders[1])
    namesOverview.append(dvdBranders[1])
    namesOverview.append(bluraySpeler[1])
    namesOverview.append(dvdSpeler[1])
    namesOverview.append(hddIdeSsd[1])
    namesOverview.append(hddSas[1])
    namesOverview.append(HddSata[1])
    namesOverview.append(HddSataSsd[1])
    namesOverview.append(hddSsh[1])
    namesOverview.append(hddSasdrie[1])
    namesOverview.append(hddSataDrie[1])
    namesOverview.append(hddSshdDrie[1])
    namesOverview.append(ddrone[1])
    namesOverview.append(ddrTwo[1])
    namesOverview.append(ddrThree[1])
    namesOverview.append(sdRam[1])
    namesOverview.append(mbMiniITX[1])
    namesOverview.append(mbSocket1150[1])
    namesOverview.append(mbSocket1155[1])
    namesOverview.append(mbSocket2011[1])
    namesOverview.append(mbSocket478[1])
    namesOverview.append(mbSocketAM[1])
    namesOverview.append(mbSocketFM[1])
    namesOverview.append(geluidskaart[1])
    namesOverview.append(behuizing[1])
    namesOverview.append(processorAMD[1])
    namesOverview.append(processor1155[1])
    namesOverview.append(processor2011[1])
    namesOverview.append(processorFm1[1])
    namesOverview.append(processorFm2[1])
    namesOverview.append(processor1150[1])
    namesOverview.append(videokaartAMD[1])
    namesOverview.append(videokaartNVIDIA[1])
    namesOverview.append(voeding[1])


# call the functions for executing. First we need te make te url/name overview before we running the real crawl function.
# when the craw(get info()) function is finished the batch will be submit and pushed to the database
createUrls()
createLabelNames()
getInfo()
batch.submit()
