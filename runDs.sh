# to run simply pass in a URL as the one and only argument to this script
# example: ./runDs.sh https://newlibre.com
#
bounceUrl="https://newlibre.com/grabit/home/getRemote2?url="

if [ -z "$1" ]; then
   echo "Please provide a valid URL. Usage: ./runDs.sh https://newlibre.com"
   exit 1
fi
## Added feature so if you provide a 2nd arg such as y (or yes) then it will 
## load the URL off the bounced website getRemote2
if [ -z "$2" ]; then 
   echo "yepper"
   dotnet run --project dragonSharq $1 -file dsView/index.htm && npm start --prefix dsView
else
   echo "$bounceUrl""$1"
   dotnet run --project dragonSharq "$bounceUrl""$1" -file dsView/index.htm && npm start --prefix dsView
fi

