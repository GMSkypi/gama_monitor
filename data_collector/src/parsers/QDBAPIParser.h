//
// Created by gama on 21.11.21.
//

#ifndef DATA_COLLECTOR_QDBAPIPARSER_H
#define DATA_COLLECTOR_QDBAPIPARSER_H

#include <string>

namespace parser {
    class QDBAPIParser {
    public:
        unsigned parseNumberOfColumn(const std::string& data);
        bool checkForError(const std::string & data);
        bool checkCreate(const std::string & data);
    };
}


#endif //DATA_COLLECTOR_QDBAPIPARSER_H
