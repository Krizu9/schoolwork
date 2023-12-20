\NeedsTeXFormat{LaTeX2e}
\ProvidesClass{jamk-report}[2022/06/14 JAMK Report]

% LaTeX class for theses written at JAMK.

%%% DECLARE OPTIONS %%%

% Languages

\DeclareOption{finnish}{}
\DeclareOption{swedish}{}
\DeclareOption{english}{}

% Other options

\DeclareOption{10pt}{\PassOptionsToClass{10pt}{article}}
\DeclareOption{11pt}{\PassOptionsToClass{11pt}{article}}

\ProcessOptions

% Based on the article class for some reason, and not the report class.
\LoadClass[titlepage,a4paper,11pt]{article} %add titlepage later

% Set paper size and margins.
% "single-sided A4 sheets"
\RequirePackage[a4paper, top=2cm, bottom=2cm, left=2cm, right=2cm]{geometry}

\RequirePackage[utf8]{inputenc}
\RequirePackage[T1]{fontenc}

% Font Noto Math Sans (switch to simple Noto if there are problems)
%\usepackage[sfdefault,scaled=0.97]{noto}
\usepackage[sfdefault, scaled=1.05]{notomath}

% List of figures customization, part 1/2 (moved here because contradictions with parskip package 28.4.2022 ++SahKa) 
\RequirePackage{tocloft}

% Spacing
\RequirePackage{setspace}
\doublespacing

% Microtypography
\usepackage[%
    activate={true,nocompatibility},%
    final,tracking=true,%
    kerning=true,%
    factor=1100,%
    stretch=20,%
    shrink=20%
]{microtype}
\microtypesetup{expansion=false}


% TODO: Short explanations why these packages are loaded
\RequirePackage{tikz}
\RequirePackage{textpos}
\RequirePackage{booktabs}
\RequirePackage{color}
\RequirePackage{enumitem}
\RequirePackage{tabularx}
\RequirePackage{blindtext}

\RequirePackage{calc}
\RequirePackage{babel}
\RequirePackage{graphicx}
\RequirePackage{acro}
\RequirePackage{array}

%https://en.wikipedia.org/wiki/Widows_and_orphans
% Disable single lines at the start of a paragraph
\clubpenalty = 10000
% Disable single lines at the end of a paragraph 
\widowpenalty = 10000
\displaywidowpenalty = 10000 % formulas

% For author list substitution
\RequirePackage{xstring}

% For date formatting
\RequirePackage[en-GB,fi]{datetime2}
\DTMsetup{useregional}
\DTMsavenow{datenow}

% Custom command for setting the date
\renewcommand{\date}[1]{\DTMsavedate{datenow}{#1}}

% Some LaTeX magic
\newif\if@grading
\newif\if@useclassification

% Intelligent quotation marks
\RequirePackage{csquotes}

% Bibliography packages and options
\RequirePackage[backend=biber,style=apa]{biblatex}
\setlength{\bibhang}{0pt}
\setlength{\bibitemsep}{12pt}

% 24pt spacing instead of indent between paragraphs
\usepackage[skip=16pt]{parskip}

% Set top margin a bit lower
\setlength{\topmargin}{-36pt}
\addtolength{\textheight}{-16pt}
\setlength{\headsep}{16pt}

% Set page number to the top right corner
\usepackage{fancyhdr}
\pagestyle{fancy}
\fancyhead{}
\fancyfoot{}
\fancyhead[R]{\thepage}
\renewcommand{\headrulewidth}{0pt}
\renewcommand{\footrulewidth}{0pt}

% Correct size for headings
\setlength{\headheight}{13.6pt}

% Caption formatting
\usepackage{caption}
\captionsetup{justification=centering,singlelinecheck=false}

\newcommand{\ra}[1]{\renewcommand{\arraystretch}{#1}}


\newcommand{\@dateofacceptance}{Date of acceptance}%
\newcommand{\@grade}{Grade}%


\newcommand{\@instructor}{Instructor}%
\newcommand{\@ccs}{ACM Computing Classification System (CCS):}%

\newcommand{\university}[1]{\renewcommand{\@university}{#1}}

% Field of studies
\newcommand{\field}[1]{\providecommand{\@field}{#1}}
\newcommand{\fieldfi}[1]{\providecommand{\@fieldfi}{#1}}

% Study programme
\newcommand{\programme}[1]{\providecommand{\@programme}{#1}}
\newcommand{\programmefi}[1]{\providecommand{\@programmefi}{#1}}

% Level of studies
\newcommand{\level}[1]{\providecommand{\@level}{#1}}
\newcommand{\levelfi}[1]{\providecommand{\@levelfi}{#1}}

% Permission for web publication
\newcommand{\webpublicationpermission}{\providecommand{\@webpublicationpermission}{}}

% Document language
\newcommand{\documentlanguage}[1]{\providecommand{\@documentlanguage}{#1}}
\newcommand{\documentlanguagefi}[1]{\providecommand{\@documentlanguagefi}{#1}}

% These are not used?
\newcommand{\supervisors}[1]{\renewcommand{\@supervisors}{#1}}
\newcommand{\assigned}[1]{\renewcommand{\@assigned}{#1}}

% Abstract and other metadata
\renewcommand{\abstract}[1]{\providecommand{\@abstract}{#1}}
\newcommand{\abstractfi}[1]{\providecommand{\@abstractfi}{#1}}
\newcommand{\keywords}[1]{\providecommand{\@keywords}{#1}}
\newcommand{\keywordsfi}[1]{\providecommand{\@keywordsfi}{#1}}
\newcommand{\miscinfo}[1]{\providecommand{\@miscinfo}{#1}}
\newcommand{\miscinfofi}[1]{\providecommand{\@miscinfofi}{#1}}

% To get number of pages
\RequirePackage{lastpage}

% Frontmatter to set page numbering style
\newcommand\frontmatter{%
    \pagenumbering{roman}}

% Mainmatter to set page numbering style
\newcommand\mainmatter{%
    \clearpage
    \pagenumbering{arabic}}

% Header logo
\newsavebox{\jamk} 
\savebox{\jamk}{\includegraphics[width=5.8cm]{src/img/jamk_header_new.png}}

% Footer logo
\newsavebox{\jamky} 
\savebox{\jamky}{\includegraphics[width=8.8cm]{src/img/jamk_footer_new.png}}

% Abstract page logo
\newsavebox{\jamks} 
\savebox{\jamks}{\includegraphics[width=3.5cm]{src/img/jamk_header_new.png}} 


\newcommand{\abst@doctype}{\fontsize{12}{9}\bf\selectfont}
\newcommand{\abst@small}{\fontsize{11}{12}\selectfont}
\newcommand{\abst@tiny}{\fontsize{9}{10}\selectfont}
\newcommand{\abst@grandtitle}{\fontsize{22}{22}\bf\selectfont}
\newcommand{\abst@grandp}{\fontsize{14}{14}\selectfont}
\newcommand{\abst@title}{\fontsize{12}{12}\bf\selectfont}


%%% Title page text generation

\newcommand{\@maketitle}{
\begin{titlepage}%
{
    \thispagestyle{empty}
    \newgeometry{textwidth=580pt, textheight=845pt}
    \noindent
    \begin{picture}(580,845)
    % Header logo placement
    \put(100,720){\usebox{\jamk}}
    % Side bar placement
    \put(50,50){\textcolor[cmyk]{1,1,0,0.60}{\rule{30pt}{750pt}}}
    
    % Prevent long titles from overflowing [fix indent?]
    \put(115, 540){
        \parbox[t]{400pt}{
        \noindent \abst@grandtitle\textbf{\@title}
        }
    }

    % Title page information
    \put(120, 450){%
        \parbox{380pt}{%
            \large
            \StrSubstitute{\@author}{,}{\\}
        }
    }
    \put(120, 210){\parbox{390pt}{%
            \large
            \@level

            \DTMenglishmonthname{\DTMfetchmonth{datenow}}\ \DTMfetchyear{datenow}

            \@field

            \@programme
        }%
    }


    % Footer placement
    \put(100,52){\usebox{\jamky}}

    \end{picture}
    \restoregeometry
    
   
}
\end{titlepage}
\clearpage
% Ugly hack to set the page counter to correct value
% I have no idea why it doesn't increment naturally
\stepcounter{page}
}

% Abstract page
\newcommand{\abstractpage}{
{\raggedright % BEGIN RAGGED
\small
\onehalfspacing
\begin{tikzpicture}[remember picture,overlay]
\node[anchor=north west,yshift=-20pt,xshift=50pt]%
    at (current page.north west)
    {\includegraphics[width=3.5cm]{src/img/jamk_header_new.png}};
\end{tikzpicture}

\thispagestyle{empty} % remove page number
\setlength{\parskip}{12pt}

\begin{textblock*}{430pt}(310pt,-28pt)
    \textbf{Description}
\end{textblock*}

\begin{textblock*}{430pt}(0pt,1cm) % {block width} (coords) 
    \textbf{\@author} % author information
    
    \textbf{\@title}
    
    Jyväskylä: JAMK University of Applied Sciences, \DTMenglishmonthname{\DTMfetchmonth{datenow}} \DTMfetchyear{datenow}, \pageref{LastPage}\ pages.
    
    \@field. \@programme. \@level.
    % Information and Communication Technologies. Degree Programme in Information and Communications Technology. \@level.
    
    Permission for web publication:
    \ifdefined\@webpublicationpermission
        Yes
    \else
        No
    \fi
    
    Language of publication: \@documentlanguage
    
    \textbf{Abstract}
    
    \@abstract
    
    \textbf{Keywords/tags (subjects)}
    
    \@keywords
    
    \textbf{Miscellaneous (Confidential information)}
    
    \@miscinfo
    
\end{textblock*}
} % END RAGGED
\clearpage
} % END \abstractpage

% Abstract page in Finnish
\newcommand{\abstractpagefi}{
{\raggedright %%% BEGIN RAGGED
\small
\onehalfspacing
\begin{tikzpicture}[remember picture,overlay]
\node[anchor=north west,yshift=-20pt,xshift=50pt]%
    at (current page.north west)
    {\includegraphics[width=3.5cm]{src/img/jamk_header_new.png}};
\end{tikzpicture}

\thispagestyle{empty} % remove page number
\setlength{\parskip}{12pt}

\begin{textblock*}{430pt}(310pt,-28pt)
    \textbf{Kuvailulehti}
\end{textblock*}

\begin{textblock*}{430pt}(0pt,1cm) % {block width} (coords) 
    \textbf{\@author} % author information
    
    \textbf{\@title}
    
    Jyväskylä: Jyväskylän ammattikorkeakoulu. \DTMfinnishMonthname{\DTMfetchmonth{datenow}} \DTMfetchyear{datenow}, \pageref{LastPage}\ sivua.
    
    \@fieldfi. \@programmefi. \@levelfi.
    
    Verkkojulkaisulupa myönnetty:
    \ifdefined\@webpublicationpermission
        kyllä
    \else
        ei
    \fi
    
    Julkaisun kieli: \@documentlanguagefi
    
    \textbf{Tiivistelmä}
    
    \@abstractfi

    \textbf{Avainsanat (asiasanat)}
    
    \@keywordsfi
    
    \textbf{Muut tiedot (salassa pidettävät liitteet)}
    
    \@miscinfofi
    
    
\end{textblock*}
} % END RAGGED
\clearpage
} % END \abstractpagefi

% List of figures customization, part 2/2
% https://tex.stackexchange.com/questions/12865/list-of-figures-how-to-add-caption-label
\renewcommand{\cftloftitlefont}{\bfseries\normalsize}
\renewcommand{\cftfigaftersnum}{.}
\renewcommand{\cftfigpresnum}{Figure }
\setlength{\cftfignumwidth}{5em}
\renewcommand{\cftlottitlefont}{\bfseries\normalsize}
\renewcommand{\cfttabaftersnum}{.}
\renewcommand{\cfttabpresnum}{Table }
\setlength{\cfttabnumwidth}{5em}
\tocloftpagestyle{fancy}

% Load hyperref last
\RequirePackage[pdftex,hidelinks]{hyperref}

%%% DOCUMENT BEGINS

\AtBeginDocument{

% Rename list of figures, tables, bibliography
\renewcommand{\listfigurename}{Figures}
\renewcommand{\listtablename}{Tables}
\renewcommand{\bibname}{References}

% Automatically set the PDF metadata fields
\hypersetup{pdftitle = {\@title}, pdfauthor = {\@author}, pdfkeywords = {\@keywords}}

% Some PDF anchor magic happening in title if hyperref used
\@ifpackageloaded{hyperref}{
    \renewcommand{\maketitle}{
        \hypersetup{pageanchor=false}
        \@maketitle
        \hypersetup{pageanchor=true}
    }
}
{
    \renewcommand{\maketitle}{\@maketitle}
}

} % End AtBeginDocument


% Figure command
%% Takes 4 parameters. width, path to image, caption and reference name. Width is optional
\newcommand{\jamkfigure}[4][6in]{
	\begin{figure}[h]
                \centering
		\includegraphics[width=#1]{#2}
		\caption{#3}
		\label{#4}
	\end{figure}
}


% Table command
% Takes 4 parameters. Caption, reference name, table layout and table contents
\newcommand{\jamktable}[4]{
    \vspace{1em}
    \begin{table}[h]
        \caption{#1}
        \begin{tabular}{ #3 }
            #4
        \end{tabular}
        \label{#2}
    \end{table}
    \vspace{1em}
}

%\newcommand{\jamkcite}[2][{}]{
%    (\cite[#1]{#2})
%}

