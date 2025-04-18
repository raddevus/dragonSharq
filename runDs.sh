# to run simply pass in a URL as the one and only argument to this script
# example: ./runDs.sh https://newlibre.com
#
if [ -z "$1" ]; then
   echo "Please provide a valid URL. Usage: ./runDs.sh https://newlibre.com"
   exit 1
fi
   
dotnet run --project dragonSharq $1 -file dsView/index.htm && npm start --prefix dsView $2
