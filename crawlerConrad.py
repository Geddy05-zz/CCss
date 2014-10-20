try:
    import urllib.request as urllib2
except:
    import urllib2
from bs4 import BeautifulSoup
from lxml import html
import re
import py2neo
from py2neo import node, rel, neo4j

blurayBranders= "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/drives-branders/interne-blu-ray-branders.html","Optische drives"
dvdBranders= "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/drives-branders/interne-dvd-branders.html","Optische drives"
bluraySpeler = "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/drives-branders/interne-blu-ray-spelers.html","Optische drives"
dvdSpeler = "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/drives-branders/interne-dvd-spelers.html","Optische drives"
hddIdeSsd="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-ide-ssd.html","Harde schijf"
hddSas ="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-sas-hdd.html","Harde schijf"
HddSata="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-sata-hdd.html","Harde schijf"
HddSataSsd="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-sata-ssd.html","Harde schijf"
hddSsh="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/25-sshd-hdd.html","Harde schijf"
hddSasdrie="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/35-sas-hdd.html","Harde schijf"
hddSataDrie="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/35-sata-hdd.html","Harde schijf"
hddSshdDrie= "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/harde-schijven/interne-harde-schijven/35-sshd-hdd.html","Harde schijf"
ddrone="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/intern-geheugen/ddr1-geheugen.html","Geheugen"
ddrTwo="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/intern-geheugen/ddr2-geheugen.html","Geheugen"
ddrThree="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/intern-geheugen/ddr3-geheugen.html","Geheugen"
sdRam= "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/intern-geheugen/sd-ram-geheugen.html","Geheugen"
processorAMD = "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/amd-socket-am3-cpus.html","processor"
mbMiniITX="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/mini-itx-moederborden.html","moederbord"
mbSocket1150="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-1150-moederborden.html","moederbord"
mbSocket1155="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-1155-moederborden.html","moederbord"
mbSocket2011="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-2011-intel-moederborden.html","moederbord"
mbSocket478="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-478-moederborden.html","moederbord"
mbSocketAM="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-am3-amd-moederborden.html","moederbord"
mbSocketFM="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/moederborden/socket-fm2-amd-moederborden.html","moederbord"
geluidskaart="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/multimedia-hardware/geluidskaarten-intern.html","geluidskaart"
behuizing="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/pc-behuizingen/pc-behuizingen.html","behuizing"
processorAMD = "https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/amd-socket-am3-cpus.html","processor"
processor1155="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/intel-socket-1155-cpus.html","processor"
processor2011="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/intel-socket-2011-cpus.html","processor"
processorFm1="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/amd-socket-fm1-cpus.html","processor"
processorFm2="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/amd-socket-fm2-cpus.html","processor"
processor1150="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/processoren/intel-socket-1150-cpus.html","processor"
videokaartAMD="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/videokaarten/videokaarten-amd-chipset.html","grafische kaart"
videokaartNVIDIA="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/videokaarten/videokaarten-nvidia-chipset.html","grafische kaart"
voeding="https://www.conrad.nl/nl/computer-kantoor/pc-componenten/voedingen/pc-voeding.html","voeding"

urlsOverview = []
namesOverview = []

graph_db = neo4j.GraphDatabaseService("http://145.24.222.101:8001/db/data/")
#http://145.24.222.101:8001/db/data/
#http://localhost:7474/db/data/


def getInfo():
    col = []
    i=0


    for url in urlsOverview:
        webpage = urllib2.urlopen(url)
        soup = BeautifulSoup(webpage)


        for item in soup.findAll("div", {"class" : "c-searchresult-list-item-details-inner"}):
            producturlinput = item.find("a",{"class" : "c-searchresult-list-item-link"}).get('href')
            producturl = "https://www.conrad.nl/"+producturlinput

            detailpagina = urllib2.urlopen(producturl)
            detailsoup = BeautifulSoup(detailpagina)
            name =str(detailsoup.find("h1", {"class": "c-productdetails-title"}).getText())
            price = str(detailsoup.find("div",{"class":"product-price"}).getText()).replace(u"\u20ac", '')
            info = []
            names = []

            for rownames in detailsoup.findAll("td" , {"class": "column-left"}):
                rname = rownames.text.replace(":","")
                names.append(str(rname))

            for rowinfo in detailsoup.findAll("td" , {"class":"column-right"}):
                rinfo = rowinfo.text
                info.append(str(rinfo))

            length = len(names);
            if length == 5:
                newNode, = graph_db.create(node({"Name": name,"Price":price, "ProductUrl": producturl, str(names[0]): str(info[0]), names[1]: info[1], names[2]: info[2], names[3]: info[3], names[4]: info[4]}))
            if length == 6:
                newNode, = graph_db.create(node({"Name": name, "ProductUrl": producturl, str(names[0]): str(info[0]), names[1]: info[1], names[2]: info[2], names[3]: info[3], names[4]: info[4], names[5]: info[5]}))
            if length == 7:
                newNode, = graph_db.create(node({"Name": name, "ProductUrl": producturl, str(names[0]): str(info[0]), names[1]: info[1], names[2]: info[2], names[3]: info[3], names[4]: info[4], names[5]: info[5], names[6]: info[6]}))
            if length == 8:
                newNode, = graph_db.create(node({"Name": name, "ProductUrl": producturl, str(names[0]): str(info[0]), names[1]: info[1], names[2]: info[2], names[3]: info[3], names[4]: info[4], names[5]: info[5], names[6]: info[6], names[7]: info[7]}))
            if length == 9:
                newNode, = graph_db.create(node({"Name": name, "ProductUrl": producturl, str(names[0]): str(info[0]), names[1]: info[1], names[2]: info[2], names[3]: info[3], names[4]: info[4], names[5]: info[5], names[6]: info[6], names[7]: info[7], names[8]: info[8]}))
            if length == 10:
                newNode, = graph_db.create(node({"Name": name, "ProductUrl": producturl, str(names[0]): str(info[0]), names[1]: info[1], names[2]: info[2], names[3]: info[3], names[4]: info[4], names[5]: info[5], names[6]: info[6], names[7]: info[7], names[8]: info[8], names[9]: info[9]}))
            if length == 11:
                newNode, = graph_db.create(node({"Name": name, "ProductUrl": producturl, str(names[0]): str(info[0]), str(names[1]): str(info[1]), str(names[2]): str(info[2]), str(names[3]): str(info[3]), str(names[4]): str(info[4]),str(names[5]): str(info[5]),str(names[6]): str(info[6]), str(names[7]): str(info[7]),str(names[8]): str(info[8]), str(names[9]): str(info[9]), str(names[10]): str(info[10])}))
            if length == 12:
                newNode, = graph_db.create(node({"Name": name, "ProductUrl": producturl, str(names[0]): str(info[0]), str(names[1]): str(info[1]), str(names[2]): str(info[2]), str(names[3]): str(info[3]), str(names[4]): str(info[4]),str(names[5]): str(info[5]),str(names[6]): str(info[6]), str(names[7]): str(info[7]),str(names[8]): str(info[8]), str(names[9]): str(info[9]), str(names[10]): str(info[10]), str(names[11]): str(info[11])}))
            if length > 13:
                newNode, = graph_db.create(node({"Name": name, "ProductUrl": producturl, str(names[0]): str(info[0]), names[1]: info[1], names[2]: info[2], names[3]: info[3], names[4]: info[4], names[5]: info[5], names[6]: info[6], names[7]: info[7], names[8]: info[8], names[9]: info[9], names[10]: info[10], names[11]: info[11], names[12]: info[12]}))


            label= str(namesOverview[i])
            newNode.add_labels(label)

            print (label)
            print (name)
            print (price)
            print (producturl)
        i=i+1





def createUrls():
    urlsOverview.append(processorAMD[0])
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
    urlsOverview.append(processorAMD[0])
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

def createLabelNames():
    namesOverview.append(processorAMD[1])
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
    namesOverview.append(processorAMD[1])
    namesOverview.append(mbMiniITX[1])
    namesOverview.append(mbSocket1150[1])
    namesOverview.append(mbSocket1155[1])
    namesOverview.append(mbSocket2011[1])
    namesOverview.append(mbSocket478[1])
    namesOverview.append(mbSocketAM[1])
    namesOverview.append(mbSocketFM[1])
    namesOverview.append(geluidskaart[0])
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


createUrls()
createLabelNames()
getInfo()